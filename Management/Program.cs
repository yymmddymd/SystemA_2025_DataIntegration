namespace Management
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // log4netÇÃèâä˙âª
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config"));

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Top());
        }
    }
}