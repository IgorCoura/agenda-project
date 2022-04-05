using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaConsole.Entities;
using AgendaConsole.Model;
using System.ComponentModel.DataAnnotations;

namespace AgendaConsole.Views
{
    public class MainView
    {
        private readonly CreateContactView _createContactView;
        private readonly EditContactView _editContactView;
        private readonly QueryContactView _queryContactView;
        private readonly RemoveContactView _removeContactView;

        public MainView(CreateContactView createContactView, EditContactView editContactView, QueryContactView queryContactView, RemoveContactView removeContactView)
        {
            _createContactView = createContactView;
            _editContactView = editContactView;
            _queryContactView = queryContactView;
            _removeContactView = removeContactView;
        }

        public void Run()
        {
            var option = "";
            while (option != "0")
            {
                option = Options();
                switch (option)
                {
                    case "1": _createContactView.Run(); break;
                    case "2": _editContactView.Run(); break;
                    case "3": _queryContactView.Run(); break;
                    case "4": _removeContactView.Run(); break;
                }
            }
        }

        public string Options()
        {
            Console.WriteLine("1-Criar novo contato.");
            Console.WriteLine("2-Editar contato existente.");
            Console.WriteLine("3-Consultar contato.");
            Console.WriteLine("4-Remover contato.");
            Console.WriteLine("0-Sair.");
            var response = Console.ReadLine() ?? "";
            Console.Clear();
            return response;
        }

        

    }
}
