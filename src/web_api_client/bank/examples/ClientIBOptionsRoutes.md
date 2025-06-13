---
layout: page
title: "Օրինակ ClientIBOptionsRoutes" 
sublinks:
- { title: "Օրինակ GetStatus", ref: օրինակ-1 }
---

## Բովանդակություն
- [GetStatus-ի օգտագործման օրինակ](#օրինակ-1)

## Օրինակ 1
Հաճախորդի ԻԲ կարգավիճակի ստացման օրինակ։

```c#
public static async Task GetStatus(BankApiClient apiClient)
{
    try
    {
        // ստանում է հաճախորդի ԻԲ կարգավիճակը
        var res = await apiClient.ClientIBOptions.GetStatus(new()
        {
            ClientCode = "00000001"
        });

        Console.WriteLine(res.Status);
    }
    catch (ApiException ex)
    {
        // մեթոդի կանչի ընթացքում սխալի առաջացման դեպքում տպում է սխալի մանրամասները
        Console.WriteLine(ex.Code);
        Console.WriteLine(ex.Message);
        Console.WriteLine(ex.StatusCode);
    }
}
```
