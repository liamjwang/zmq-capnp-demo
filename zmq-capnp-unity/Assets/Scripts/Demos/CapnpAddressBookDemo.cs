using System.IO;
using Capnp;
using CapnpGen;
using UnityEngine;

public class CapnpAddressBookDemo : MonoBehaviour
{
    private void Start()
    {


        var addressBook = new AddressBook()
        {
            People = new Person[]
            {
                new Person()
                {
                    Id = 1234,
                    Name = "Mark Harthaw",
                    Email = "mark.harthaw@soylent.corp",
                    Phones = new Person.PhoneNumber[]
                    {
                        new Person.PhoneNumber() {TheType = Person.PhoneNumber.Type.work, Number = "12345678"},
                        new Person.PhoneNumber() {TheType = Person.PhoneNumber.Type.mobile, Number = "87654321"}
                    },
                    Employment = new Person.employment()
                    {
                        Employer = "Soylent Corp"
                    }
                },
                new Person()
                {
                    Id = 4321,
                    Name = "John Doe",
                    Employment = new Person.employment()
                    {
                        which = Person.employment.WHICH.SelfEmployed
                    }
                }
            }
        };

        var msg = MessageBuilder.Create();
        var root = msg.BuildRoot<AddressBook.WRITER>();
        addressBook.serialize(root);

        var mems = new MemoryStream();
        var pump = new FramePump(mems);
        pump.Send(msg.Frame);
        mems.Seek(0, SeekOrigin.Begin);

        var frame = Framing.ReadSegments(mems);

        var deserializer = DeserializerState.CreateRoot(frame);
        var reader = new AddressBook.READER(deserializer);
    
        Debug.Log(reader.People[0].Name);
        foreach (var person in reader.People)
        {
            Debug.Log($"Id: {person.Id}");
            Debug.Log($"Name: {person.Name}");
            Debug.Log($"E-mail: {person.Email}");
            if (person.Phones?.Count > 0)
            {
                foreach (var phone in person.Phones)
                {
                    Debug.Log($"{phone.TheType}: {phone.Number}");
                }
            }

            Debug.Log($"Employment: {person.Employment.which}");
            switch (person.Employment.which)
            {
                case Person.employment.WHICH.Employer:
                    Debug.Log($"Employer: {person.Employment.Employer}");
                    break;

                case Person.employment.WHICH.School:
                    Debug.Log($"School: {person.Employment.School}");
                    break;
            }
        }

    }

}