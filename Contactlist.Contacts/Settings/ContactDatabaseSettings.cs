namespace Contactlist.Contacts.Settings
{
    public class ContactDatabaseSettings: IContactDatabaseSettings
    {
        public string ConnectionStrings { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
    }
}
