using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaConsole.Entities;
using AgendaConsole.Model;
using System.ComponentModel.DataAnnotations;
using AgendaConsole.Interfaces;

namespace AgendaConsole.Utils
{
    public class MainView : IView
    {
        private readonly IView _createContactView;
        private readonly IView _editContactView;
        private readonly IView _queryContactView;
        private readonly IView _removeContactView;
        private readonly IContactService _contactService;

        public MainView(IContactService contactService, IView createContactView, IView editContactView, IView queryContactView, IView removeContactView)
        {
            _contactService = contactService;
            _createContactView = createContactView;
            _editContactView = editContactView;
            _queryContactView = queryContactView;
            _removeContactView = removeContactView;
        }

        public void Run()
        {
            while (true)
            {
                var option = Options();
                try
                {
                    switch (option)
                    {
                        case "0":return;
                        case "1": _createContactView.Run(); break;
                        case "2":_editContactView.Run();break;
                        case "3":_queryContactView.Run(); break;
                        case "4":_removeContactView.Run(); break;
                        case "5":SaveChanges();break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
                
            }
        }

        private string Options()
        {
            Console.WriteLine("1-Criar novo contato.");
            Console.WriteLine("2-Editar contato existente.");
            Console.WriteLine("3-Consultar contato.");
            Console.WriteLine("4-Remover contato.");
            Console.WriteLine("5-Salvar todas as alteações.");
            Console.WriteLine("0-Sair (Salve antes de sair).");
            var response = Console.ReadLine() ?? "";
            Console.Clear();
            return response;
        }

        private void SaveChanges()
        {
            _contactService.SaveChangesAsync();
        }

    }
}
