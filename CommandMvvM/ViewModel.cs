using System.Windows;

namespace CommandMvvM
{
    public class ViewModel
    {
        public Command MeuCommand { get; set; }
        public Command<string> MeuCommand2 { get; set; }

        public ViewModel()
        {
            MeuCommand = new Command(Acao);
            MeuCommand2 = new Command<string>(Acao2);
        }

        protected void Acao2(string obj)
        {
            MessageBox.Show(obj);
        }

        protected void Acao()
        {
            MessageBox.Show("Meu primeiro Command!");
        }
    }
}
