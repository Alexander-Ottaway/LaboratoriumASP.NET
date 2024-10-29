namespace WebApp.Models.Services;

public class MemoryContactService: IContactService
{
    private  Dictionary<int, ContactModel> _contacts = new()
    {// klamra _contacts = new()
        { // klamra wpisu
            1,
            new ContactModel()
            {// klamra new Contact()
                Id = 1,
                Category = Category.Friend,
                FirstName = "Alexander",
                LastName = "Ottaway",
                Email = "adres@gmail.com",
                PhoneNumber = "777 777 777",
                BirthDate = new DateOnly(2002, 10, 29)
            }
        },
        {
            2,
            new ContactModel()
            {
                Id = 2,
                Category = Category.Family,
                FirstName = "Jagoda",
                LastName = "Kasperek",
                Email = "adres2@gmail.com",
                PhoneNumber = "444 444 444",
                BirthDate = new DateOnly(2002, 9, 14)
            }
        },
        
    };

    private  int currentId = 3;
    
    public void Add(ContactModel model)
    {
        model.Id = ++currentId;
        _contacts.Add(model.Id, model);
    }

    public void Update(ContactModel model)
    {
        if (_contacts.ContainsKey(model.Id))
        {
            _contacts[model.Id] = model;
        }
    }

    public void Delete(int id)
    {
        _contacts.Remove(id);
    }

    public List<ContactModel> GetAll()
    {
        return _contacts.Values.ToList();
    }

    public ContactModel? GetById(int id)
    {
        return _contacts[id];
    }
}