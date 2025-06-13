---
layout: page
title: "ClientIBOptionsRoutes դաս" 
sublinks:
- { title: "GetStatus", ref: getstatus }
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Մեթոդներ](#մեթոդներ)
  - [GetStatus](#getstatus)

## Ներածություն

ClientIBOptionsRoutes դասը պարունակում է մեթոդներ հաճախորդների ԻԲ կարգավորումների տվյալների հետ աշխատանքը ապահովելու համար։
Այն հասանելի է [BankApiClient](../types/BankApiClient.md) դասի միջից։

## Մեթոդներ

### GetStatus

```c#
public Task<GetStatusResponse> GetStatus(GetStatusRequest request)
```

Վերադարձնում է հաճախորդի ԻԲ կարգավիճակը։
Եթե հաճախորդի համար ԻԲ կարգավորում արված չէ, նույնպես վերադարձնում է "0"։

**Պարամետրեր**

* `request` - Պարունակում է հաճախորդի կոդը։

**Վերադարձվող արժեքներ**

* `Status` - կարգավիճակի կոդ։

Հնարավոր արժեքներն են`

| Status | Նկարագրություն |
| -- | -- |
| 0 | Չօգտագործող |
| 1 | Գրանցված |
| 2 | Օգտագործող |
| 3 | Սառեցված |

**Օրինակ**

Տե՛ս օգտագործման [օրինակը](../examples/ClientIBOptionsRoutes.md#օրինակ-1)։
