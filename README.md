# DickinsonBros.DataTable

<a href="https://www.nuget.org/packages/DickinsonBros.DataTable/">
    <img src="https://img.shields.io/nuget/v/DickinsonBros.DataTable">
</a>

A DataTable Service

Features
* Methods: ToDataTable
* Takes IEnumable of T and converts it into a DataTable
* Handles nested interfaces, and anonymous enumerables
* Vaild Data Types Include: Primitive, Value, String, and ByteArrays
* Throws on invaild Enums 
* Uses MemoryCache to reduce need for reflection on repeat usage

Requires: IMemoryCache

<a href="https://dev.azure.com/marksamdickinson/DickinsonBros/_build?definitionScope=%5CDickinsonBros.DataTable">Builds</a>

<h2>Example Usage</h2>

```C#
    public class SampleClass
    {
      string FirstName { get; set; }
      int Age { get; set; }
    }

    var sampleClassList = new List<SampleClass>
    {
        new SampleClass
        {
            FirstName = "SampleFirstName",
            Age = 30
        }
    };

    var dataTableOne = dataTableService.ToDataTable(sampleClassList, "mySampleTable");

    var anonymousSampleList = new List<string>
    {
        "FirstString",
        "SecondString"
    };

    var dataTableTwo = dataTableService.ToDataTable(anonymousSample, "myTable");

```
