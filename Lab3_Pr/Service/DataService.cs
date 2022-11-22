using Lab3_Pr.Models;

namespace Lab3_Pr.Service;

public class DataService
{
    private List<CountryCapital> Data { get; set; } = new();

    public CountryCapital Add(CountryCapitalModel element)
    {
        var toAdd = new CountryCapital()
        {
            Id = Guid.NewGuid(),
            CountryName = element.CountryName,
            CapitalName = element.CapitalName
        };
        Data.Add(toAdd);
        return toAdd;
    }

    public CountryCapital GetById(Guid id)
    {
        var toReturn = Data.FirstOrDefault(x => x.Id==id);
        return toReturn;
    }

    public List<CountryCapital> GetAll()
    {
        return Data.ToList();
    }

    private void Delete(CountryCapital element)
    {
        Data.Remove(element);
    }

    public void DeleteById(Guid id)
    {
        var element = GetById(id);
        Delete(element);
    }

    public void DeleteAll()
    {
        while (Data.Count!=0)
        {
            Delete(Data[0]);
        }
    }

    public CountryCapital Update(Guid id, CountryCapitalModel updatedObject)
    {
        var element = GetById(id);
        Data.Remove(element);
        element.CapitalName = updatedObject.CapitalName;
        element.CountryName = updatedObject.CountryName;
        Data.Add(element);
        return element;
    }
}