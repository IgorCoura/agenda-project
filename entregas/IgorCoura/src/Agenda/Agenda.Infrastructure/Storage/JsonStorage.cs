using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Agenda.Domain.Entities;
using Agenda.Domain.Interfaces;
using Microsoft.Extensions.Options;

namespace Agenda.Infrastructure.Storage
{
    public class JsonStorage<T> : IJsonStorage<T> where T : Register
    {
        private readonly string _filePath;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private readonly List<T> _context;
        private readonly JsonStorageOptions _options;
        public IEnumerable<T> Context => _context;

        public JsonStorage(IOptions<JsonStorageOptions> options)
        {
            _options = options.Value ?? new JsonStorageOptions();
            _filePath = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + _options.FilePath;
            _jsonSerializerOptions = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true
            };
            _context = ReadFile().ToList();
        }

        public int CreateId()
        {
            return _context.Any() ? _context.LastOrDefault()!.Id + 1 : _context.Count() + 1;
        }
        public T Create(T model)
        {
            try
            {
                model.CreatedAt = DateTime.Now;
                model.UpdatedAt = DateTime.Now;

                _context.Add(model);

                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _context;
        }

        public T GetById(int id)
        {
            return _context.FirstOrDefault(x => x.Id == id) ?? throw new ArgumentNullException($"Entidade com o id: {id}, não encontado");
        }

        public T Remove(int id)
        {
            try
            {
                var model = GetById(id);
                if (model is null)
                    throw new Exception($"${typeof(T)} não encontrado");

                if (!_context.Remove(model))
                    throw new Exception($"Falha ao remover ${typeof(T)}");

                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public T Update(T model)
        {
            try
            {
                var result = GetById(model.Id);
                if (result is null)
                    throw new Exception($"${typeof(T)} não encontrado");

                model.UpdatedAt = DateTime.Now;

                _context[_context.IndexOf(result)] = model;
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task SaveAsync()
        {
            try
            {
                if (!FileExists())
                    File.Create(_filePath).Close();

                await File.WriteAllTextAsync(
                    _filePath,
                    JsonSerializer.Serialize(_context, _jsonSerializerOptions),
                    Encoding.UTF8
                );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private IEnumerable<T> ReadFile()
        {
            if (!FileExists())
                return new List<T>();

            var result = File.ReadAllText(_filePath);

            if (string.IsNullOrEmpty(result))
                return new List<T>();

            try
            {
                return JsonSerializer.Deserialize<IEnumerable<T>>(result) ?? new List<T>();
            }
            catch (JsonException ex)
            {
                throw new FileLoadException($"Erro ao iniciar arquivo: ${ex}");
            }
            catch(Exception ex)
            {
                throw new Exception($"Erro ao iniciar o arquivo {ex}. Erro: {ex.Message}");
            }
        }

        private bool FileExists()
        {
            return File.Exists(_filePath);
        }
    }
}
