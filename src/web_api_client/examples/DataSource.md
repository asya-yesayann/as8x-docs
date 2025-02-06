---
layout: page
title: "Տվյալների աղբյուրի կլիենտից կանչի օրինակ" 
tags: [DS, DataSource]
sublinks:
- { title: "ExecuteAsync", ref: օրինակ-1 }
- { title: "LongExecuteAsync", ref: օրինակ-2 }
- { title: "Տիպիզացված", ref: օրինակ-3 }
- { title: "DSDefinitionsCache", ref: օրինակ-4 }
---

## Բովանդակություն

- [Տվյալների աղբյուրի կլիենտից կանչի օրինակ ոչ տիպիզացված եղանակով](#օրինակ-1)
- [Տվյալների աղբյուրի և ընդլայնման կլիենտից կանչի օրինակ ոչ տիպիզացված եղանակով](#օրինակ-2)
- [Տվյալների աղբյուրի կլիենտից կանչի օրինակ տիպիզացված եղանակով](#օրինակ-3)
- [Տվյալների աղբյուրի կլիենտից կանչի օրինակ՝ օգտագործելով քեշավորում](#օրինակ-4)

## Օրինակ 1

Ներկայացված է տվյալների աղբյուրի կանչի օրինակ կլիենտից։  
Այս օրինակում տվյալների աղբյուրը աշխատացվում է [ExecuteAsync](../routes/DataSource.md#executeasync) մեթոդի միջոցով, քանի որ կատարման ժամանակը և արդյունքը փոքր է։  
Տվյալների աղբյուրի պարամետրերը և կատարման արդյունքի սյուները ներկայացված են ոչ տիպիզացված եղանակով՝ համապատասխանաբար `ParameterCollection` և `ExtendableRow` դասերի միջոցով։  
Այս դեպքում պարամետրերի արժեքները փոխանցվում են և սյան արժեքները ստացվում են indexer-ի միջոցով, ինչի պատճառով կոմպիլյացիայի ժամանակ դրանց տիպի ստուգում տեղի չի ունենում։

Օրինակում ներկայացված տվյալների աղբյուրի սերվիսային նկարագրությանը ծանոթանալու համար [տե՛ս](../../server_api/examples/ds/sql_based_code.cs):

```c#
async Task RunDynamicDS1(ApiClient apiClient)
{
    // Ստեղծում է DataSource դասի օբյեկտ, Client հատկությանը փոխանցելով ApiClient դասի օբյեկտ:
    var ds = new DataSource()
    {
        Client = apiClient
    };

    // Բեռնում է տվյալների աղբյուրի նկարագրությունը՝ ըստ ներքին անվան։
    await ds.LoadDefinitionAsync("TreeNode");

    // Պարամետրերի նկարագրման համար անհրաժեշտ է ստեղծել ParameterCollection դասի օբյեկտ՝
    // Definition հատկությանը պարտադիր փոխանցելով տվյալների աղբյուրի Definition-ի Parameters հատկությունը։
    var parameters = new ParameterCollection() { Definition = ds.Definition.Parameters };

    // parameters օբյեկտի մեջ նշել պարամետրերի արժեքները՝ 
    // նշելով պարամետրի անունը և փոխանցելով անհրաժեշտ արժեքը։
    parameters["TreeId"] = "Banks";
    parameters["NodeType"] = "1";

    // Տվյալների աղբյուրը աշխատացվում է ExecuteAsync մեթոդով փոխանցելով պարամետրերը։
    // Քանի որ վերադարձվող սյուների անունները որպես պարամետր փոխանցված չեն, ապա կատարման արդյունքում կվերադարձվեն բոլոր սյուները։
    var dsResult = await ds.ExecuteAsync(parameters);

    // Տվյալների աղբյուրի տողերը ստանում է Rows հատկությանից։
    foreach (var row in dsresult.Rows)
    {
        // Սյան արժեքը ստանալու համար դիմում է ըստ սյան անվան։
        Debug.WriteLine(row["Code"]);
        Debug.WriteLine(row["Name"]);
    }
}
```

## Օրինակ 2

Ներկայացված է տվյալների աղբյուրի և իր ընդլայնման կանչի օրինակ կլիենտից։

Այս օրինակում տվյալների աղբյուրը կատարվում է [LongExecuteAsync](../routes/DataSource.md#longexecuteasync) մեթոդի միջոցով, քանի որ կատարման ժամանակը մեծ է։  
Տվյալների աղբյուրի պարամետրերը և կատարման արդյունքի սյուները ներկայացված են ոչ տիպիզացված եղանակով՝ համապատասխանաբար `ParameterCollection` և `ExtendableRow` դասերի միջոցով։  
Այս դեպքում պարամետրերի արժեքները փոխանցվում են և սյան արժեքները ստացվում են indexer-ի միջոցով, ինչի պատճառով կոմպիլյացիայի ժամանակ դրանց տիպի ստուգում տեղի չի ունենում։

```c#
async Task RunDynamicDS2(ApiClient apiClient)
{
    // Ստեղծում է DataSource դասի օբյեկտ, Client հատկությանը փոխանցելով ApiClient դասի օբյեկտ:
    var ds = new DataSource()
    {
        Client = apiClient
    };

    //Բեռնում է տվյալների աղբյուրի նկարագրությունը՝ ըստ ներքին անվան։
    await ds.LoadDefinitionAsync("TreeNode");

    // Պարամետրերի նկարագրման համար անհրաժեշտ է ստեղծել ParameterCollection դասի օբյեկտ՝
    // Definition հատկությանը պարտադիր փոխանցելով տվյալների աղբյուրի Definition-ի Parameters հատկությունը։
    var parameters = new ParameterCollection() { Definition = ds.Definition.Parameters };

    // parameters օբյեկտի մեջ նշել պարամետրերի արժեքները՝ 
    // նշելով պարամետրի անունը և փոխանցելով անհրաժեշտ արժեքը։
    parameters["TreeId"] = "Banks";
    parameters["NodeType"] = "1";

    // Ստանում է տվյալների աղբյուրի նկարագրությունը GetSchema մեթոդի միջոցով՝ փոխանցելով ընդլայնման ներքին անունը։
    var extenderDefinition = new ExtenderSchemaEx(apiClient.Extender.GetSchema("TreeNodeExtended"));

    // Նշվում է տվյալների աղբյուրի աշխատանքի ընթացքում օգտագործվող ընլայնումը։
    ds.ExtenderSchema = extenderDefinition;

    // Տվյալների աղբյուրը աշխատացվում է LongExecuteAsync մեթոդով փոխանցելով պարամետրերը և վերադարձվող սյուների անունները: 
    // Ընդլայնման սյուները վերադարձնելու համար անհրաժեշտ է փոխանցել սյան անունները "Entender_" նախդիրով:
    // Վերադարձվող սյուների անունները չնշելու դեպքում վերադարձվելու են տվյալների աղբյուրի և ընդլայնման բոլոր սյուները։
    var columns = new HashSet<string> { "Code", "Extender_Amsativ" }; 
    var dsResult = await ds.LongExecuteAsync(parameters, columns);

    // Տվյալների աղբյուրի տողերը ստանում է Rows հատկությանից։
    foreach (var row in dsresult.Rows)
    {
        // Սյան արժեքը ստանալու համար դիմում է ըստ սյան անվան
        Debug.WriteLine(row["Code"]);

        // Սյան արժեքը ստանալու համար դիմում է ըստ սյան անվան "Entender_" նախդիրով։
        Debug.WriteLine(row["Extender_Amsativ"]);
    }
}
```

## Օրինակ 3

Ներկայացված է տվյալների աղբյուրի կանչի օրինակ կլիենտից։

Այս օրինակում տվյալների աղբյուրը կատարվում է [ExecuteAsync](../routes/DataSource.md#executeasync) մեթոդի միջոցով, քանի որ կատարման ժամանակը փոքր է։

Տվյալների աղբյուրի պարամետրերը և կատարման արդյունքի սյուները ներկայացված են տիպիզացված եղանակով՝ այսինքն սահմանված են դասեր տվյալների աղբյուրի պարամետրերի և տողի նկարագրման համար, որոնք ժառանգում են համապատասխանաբար `ParameterCollection` և `ExtendableRow` դասերից։  
Այս դեպքում պարամետրերի արժեքները փոխանցվում են դասի հատկությունների միջոցով, հետևաբար կոմպիլյացիայի ժամանակ տիպի ստուգում է տեղի ունենում։

Օրինակում ներկայացված տվյալների աղբյուրի սերվիսային նկարագրությանը ծանոթանալու համար [տե՛ս](../../server_api/examples/ds/sql_based_code.cs):

```c#
public class DataRow : ExtendableRow
{
    public string Code { get; set; }
    public string Name { get; set; }
}

public class Param : ParameterCollection
{
    public string TreeId
    {
        get { return (string)base[nameof(this.TreeId)]; }
        set { base[nameof(this.TreeId)] = value; }
    }
    public string NodeType
    {
        get { return (string)base[nameof(this.NodeType)]; }
        set { base[nameof(this.NodeType)] = value; }
    }
}
```

```c#
async Task RunDynamicDS3(ApiClient apiClient)
{
    // Ստեղծում է DataSource դասի օբյեկտ, որը ստանում է պարամետրերը և սյուները նկարագրող տիպիզացված դասերը։
    // Client հատկությանը փոխանցում է ApiClient դասի օբյեկտ:
    var ds = new DataSource<DataRow, Param>
    {
        Client = apiClient
    };

    // Բեռնում է տվյալների աղբյուրի նկարագրությունը՝ ըստ ներքին անվան։
    await ds.LoadDefinitionAsync("TreeNode");

    // Պարամետրերի արժեքավորման համար անհրաժեշտ է պարամետրերը նկարագրող դասի օբյեկտ՝
    // Definition հատկությանը պարտադիր փոխանցելով տվյալների աղբյուրի Definition-ի Parameters հատկությունը և պարամետրերին փոխանցելով անհրաժեշտ արժեքները։
    var parameters = new Param() 
    { 
        Definition = ds.Definition.Parameters, 
        TreeId = "Banks",
        NodeType = "1"
    };

    // Տվյալների աղբյուրը աշխատացվում է ExecuteAsync մեթոդով փոխանցելով պարամետրերը։
    // Քանի որ վերադարձվող սյուների անունները որպես պարամետր փոխանցված չեն, ապա կատարման արդյունքում կվերադարձվեն բոլոր սյուները։
    var dsResult = await ds.ExecuteAsync(parameters);

    // Տվյալների աղբյուրի տողերը ստանում է Rows հատկությանից։
    foreach (var row in dsresult.Rows)
    {
        // Տողի սյան արժեքը ստանալու համար դիմում է համապատասխան հատկությանը
        Debug.WriteLine(row.Code);
        Debug.WriteLine(row.Name);
    }
}
```

## Օրինակ 4

Այս օրինակում ներկայացված է տվյալների աղբյուրի կատարման օրինակ ընդլայնումով, օգտագործելով տվյալների աղբյուրի և ընդլայնման նկարագրությունների քեշավորում, որը հանդիսանում է [Օրինակ 2](#օրինակ-2)-ի ձևափոխված տարբերակը։

```c#
public static class DSDefinitionsCache
{
    //....
    private static ConcurrentDictionary<string, DataSourceDefinition> dsDefinitions = new();

    private static ConcurrentDictionary<string, ExtenderSchema> extenderDefinitions = new();

    public static async Task<DataSourceDefinition> GetDataSourceDefinition(string name)
    {
        if (dsDefinitions.TryGetValue(name, out var result))
        {
            return result;
        }
        else
        {
            var ds = new DataSource()
            {
                Client = this.apiClient
            };
            await ds.LoadDefinitionAsync(name);
            dsDefinitions.TryAdd(name, ds.Definition);
            return dsDefinitions[name];
        }
    }
    
    public static ExtenderSchemaEx GetExtenderDefinition(string name)
    {
        if (extenderDefinitions.TryGetValue(name, out var result))
        {
            return result;
        }
        else
        {
            var extenderDefinition = new ExtenderSchemaEx(this.apiClient.Extender.GetSchema(name));
            extenderDefinitions.TryAdd(name, extenderDefinition);
            return extenderDefinition;
        }
    }
    //...
}
```

```c#
async Task RunDynamicDS4(ApiClient apiClient)
{
    // Տվյալների աղբյուրի նկարագրության ստացում
    var definition = await DSDefinitionsCache.GetDataSourceDefinition("TreeNode");

    // Տվյալների աղբյուրի ընդլայնման նկարագրության ստացում
    var extenderDefinition = DSDefinitionsCache.GetExtenderDefinition("TreeNodeExtended");

    // Ստեղծում է DataSource դասի օբյեկտ, լրացնելով Client, տվյալների աղբյուր և ընդլայնում հատկությունները։
    var ds = new DataSource()
    {
        Client = apiClient,
        Definition = definition,
        ExtenderSchema = extenderSchemaEx
    };

    // Պարամետրերի նկարագրման համար անհրաժեշտ է ստեղծել ParameterCollection դասի օբյեկտ՝
    // Definition հատկությանը պարտադիր փոխանցելով տվյալների աղբյուրի Definition-ի Parameters հատկությունը։
    var parameters = new ParameterCollection() { Definition = ds.Definition.Parameters };

    // parameters օբյեկտի մեջ նշել պարամետրերի արժեքները՝ 
    // նշելով պարամետրի անունը և փոխանցելով անհրաժեշտ արժեքը։
    parameters["TreeId"] = "Banks";
    parameters["NodeType"] = "1";

    // Տվյալների աղբյուրը աշխատացվում է ExecuteAsync մեթոդով փոխանցելով պարամետրերը։
    // Քանի որ վերադարձվող սյուների անունները որպես պարամետր փոխանցված չեն, ապա կատարման արդյունքում կվերադարձվեն բոլոր սյուները։
    var dsResult = await ds.ExecuteAsync(parameters);

    // Տվյալների աղբյուրի տողերը ստանում է Rows հատկությանից։
    foreach (var row in dsresult.Rows)
    {
        // Սյան արժեքը ստանալու համար դիմում է ըստ սյան անվան։
        Debug.WriteLine(row["Code"]);
        Debug.WriteLine(row["Extender_Amsativ"]);
    }
}
```