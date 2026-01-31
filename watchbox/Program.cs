namespace watchbox
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ApplicationConfiguration.Initialize();

            try
            {
                DB.EnsureDatabase();
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(
                    "Uygulama bu klasöre yazamýyor.\n" +
                    "Zip'i masaüstüne/indirilenler gibi yazýlabilir bir klasöre çýkarýp tekrar deneyin.\n\n" +
                    ex.Message,
                    "Watchbox - Dosya Ýzni",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Veritabaný hazýrlanýrken bir hata oluþtu.\n\n" + ex,
                    "Watchbox - Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            Application.Run(new FormLogin());
        }
    }
}