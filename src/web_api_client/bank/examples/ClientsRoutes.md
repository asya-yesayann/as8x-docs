---
layout: page
title: "Օրինակ ClientsRoutes" 
sublinks:
- { title: "Օրինակ CreatePhysicalClientByFullData", ref: օրինակ-1 }
- { title: "Օրինակ CreateClientFromEkeng", ref: օրինակ-2 }
---

## Բովանդակություն
- [CreateClientFromEkeng-ի օգտագործման օրինակ](#օրինակ-1)
- [CreatePhysicalClientByFullData-ի օգտագործման օրինակ](#օրինակ-2)

## Օրինակ 1

Նոր ֆիզ. անձ հաճախորդի ստեղծման օրինակ ԷԿԵՆԳ համակարգից ստանալով անձի տվյալները։

```c#
public static async Task CreateClientFromEkeng(BankApiClient apiClient)
{
    try
    {
        // ստեղծում է ֆիզիկական անձ տիպի հաճախորդ՝ նշելով անձը հաստատող փաստաթղթի համարներից մեկը և ռեզիդենտությունը
        var res = await apiClient.Clients.CreateClientFromEkeng(new()
        {
            PersonSSN = "1234567891",     //Սոց.քարտի համարը
            //PassCode = "AH1234567891",  //Անձնագրի համար
            //TaxNumber = "1234567891",   //Անհատ ձեռնարկատիրոջ ՀՎՀՀ
            Resident = true,            //Հաճախորդի ռեզիդենտություն (ՊԱՐՏԱԴԻՐ Է)

            EMail = "test@mail.am",     //էլ.փոստ
            Mobile = "374 91111111",    //Բջջ.հեռախոսահամար
        });

        Console.WriteLine(res.IsNewCreated);
        Console.WriteLine(res.Client);          //Վերադարձնում է ստեղծված հաճախորդի համարը
    }
    catch (ApiException ex)
    {
        // մեթոդի կանչի ընթացքում սխալի առաջացման դեպքում տպում է սխալի մանրամասները
        Console.WriteLine(ex.Code); // սխալի կոդ
        Console.WriteLine(ex.Message); // սխալի հաղորդագրություն
        Console.WriteLine(ex.StatusCode); // սխալի վիճակի կոդ
    }
}
```

## Օրինակ 2

Նոր ֆիզ. անձ հաճախորդի ստեղծման օրինակ։

```c#
private static async Task CreateClient(BankApiClient apiClient)
{
    try
    {
        // ստեղծում է ֆիզիկական անձ տիպի հաճախորդ՝ նշելով անհրաժեշտ տվյալները
        var res = await apiClient.Clients.CreatePhysicalClientByFullData(new()
        {
            // հաճախորդի անձնագրի տվյալներ
            Passport = new()
            {
                PassCode = "AH1234567891", // կոդ
                PassType = "01", //տեսակ
                PassBy = "001", // ում կողմից է տրված
                DatePass = new DateTime(2020, 11, 15), // տրման ամսաթիվ
                DateExpire = new DateTime(2030, 11, 15), // վավեր է մինչև
            },

            FirstName = "Պողոս".ToArmenianANSI(), // հաճախորդի անուն
            LastName = "Պողոսյան".ToArmenianANSI(), // հաճախորդի ազգանուն
            Resident = true, // հաճախորդի ռեզիդենտության հայտանիշ
            ResidenceCountry = "AM", // հաճախորդի ռեզիդենտության երկրի կոդ
            RelatedWithBank = false, // հաճախորդը ունի բանկի հետ կապվածություն թե ոչ
            IsBankEmployee = false, // հաճախորդը հանդիսանում է բանկի աշխատակից թե ոչ
            CitizenshipCountry = "AM", // հաճախորդի քաղաքացիության երկրի կոդ
            StmtType = ArmSoft.AS8X.Public.BankModels.Clients.StatementDeliverModes.Bank, // քաղվածքի ստացման եղանակ
            OtherFieldValues = new() { { "UDRWCOUNT", "555" } },
            SSNNumber = "1234567891", // սոց. քարտի համար
            SSNDate = new DateTime(2020, 11, 15), // սոց. քարտ-ի տրման ամսաթիվ
            SSNType = "2", // սոց. քարտի տիպ
        });

        
        Console.WriteLine(res.Client);  // տպում է ստեղծված հաճախորդի կոդը
        Console.WriteLine(res.IsFinalState);  //ստեղծված հաճախորդը վերջնական վիճակում է
    }
    catch (ApiException ex)
    {
        // մեթոդի կանչի ընթացքում սխալի առաջացման դեպքում տպում է սխալի մանրամասները
        Console.WriteLine(ex.Code); // սխալի կոդ
        Console.WriteLine(ex.Message); // սխալի հաղորդագրություն
        Console.WriteLine(ex.StatusCode); // սխալի վիճակի կոդ
    } 
}
```