# DickinsonBros.DataTable

<a href="https://dev.azure.com/marksamdickinson/dickinsonbros/_build/latest?definitionId=68&amp;branchName=master"> <img alt="Azure DevOps builds (branch)" src="https://img.shields.io/azure-devops/build/marksamdickinson/DickinsonBros/68/master"> </a> <a href="https://dev.azure.com/marksamdickinson/dickinsonbros/_build/latest?definitionId=68&amp;branchName=master"> <img alt="Azure DevOps coverage (branch)" src="https://img.shields.io/azure-devops/coverage/marksamdickinson/dickinsonbros/68/master"> </a><a href="https://dev.azure.com/marksamdickinson/DickinsonBros/_release?_a=releases&view=mine&definitionId=32"> <img alt="Azure DevOps releases" src="https://img.shields.io/azure-devops/release/marksamdickinson/b5a46403-83bb-4d18-987f-81b0483ef43e/32/33"> </a><a href="https://www.nuget.org/packages/DickinsonBros.DataTable/"><img src="https://img.shields.io/nuget/v/DickinsonBros.DataTable"></a>

A DataTable Service

Features
* Methods: ToDataTable
* Takes IEnumable of T and converts it into a DataTable
* Handles nested interfaces, and anonymous enumerables
* Vaild Data Types Include: Primitive, Value, String, and ByteArrays
* Throws on invaild Enums 
* Uses MemoryCache to reduce need for reflection on repeat usage

Requires: IMemoryCache

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
