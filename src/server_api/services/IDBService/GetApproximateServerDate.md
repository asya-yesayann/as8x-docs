---
title: IDBService.GetApproximateServerDate() մեթոդ
---

```c#
public Task<DateTime> GetApproximateServerDate();
```

Վերադարձնում է SQL սերվիսի ընթացիկ ամսաթիվը/ժամը որոշակի շեղման հավանականությամբ։

Ավելի արագ է աշխատում քան [GetServerDate](GetServerDate.md), քանզի աշխատում է ամեն անգամ SQL չկատարելու սկզբունքով։

<!-- ### GetContext

```c#
public byte[] GetContext(string defaultValue = null);
```

8X սերվիս լոգին լինելուց բացվում է սեսսիա, որի մեջ պահվում է մուտք գործողի մասին ինֆորմացիան։

Մեթոդը վերադարձնում է սեսսիայի մասին կոնտեքստային ինֆորմացիան (մուտք գործած օգտատիրոջ, բացված սեսսիայի id-ները, օգտատիրոջ աշխատանքային տեղի անունը և `defaultValue` պարամետրը) որպես byte-երի զանգված։ 

**Պարամետրեր**
* `defaultValue` - Սովորաբար նշվում է այն դասի անունը, որը կանչում է այս մեթոդը։ Լռությամբ արժեքը **null** է։ -->

<!-- ### SetContext

```c#
public void SetContext(string value);
```

8X սերվիս լոգին լինելուց բացվում է սեսսիա, որի մեջ պահվում է մուտք գործողի մասին ինֆորմացիան։

Մեթոդը գրանցում է սեսսիայի մասին կոնտեքստային ինֆորմացիան (մուտք գործած օգտատիրոջ, բացված սեսսիայի id-ները, օգտատիրոջ աշխատանքային տեղի անունը և `defaultValue` պարամետրը) որպես byte-երի զանգված տվյալների պահոցի [sys.dm_exec_requests](https://learn.microsoft.com/en-us/sql/relational-databases/system-dynamic-management-views/sys-dm-exec-requests-transact-sql?view=sql-server-ver16), [sys.dm_exec_sessions](https://learn.microsoft.com/en-us/sql/relational-databases/system-dynamic-management-views/sys-dm-exec-sessions-transact-sql?view=sql-server-ver16), [sys.sysprocesses](https://learn.microsoft.com/en-us/sql/relational-databases/system-compatibility-views/sys-sysprocesses-transact-sql?view=sql-server-ver16) համակարգային աղյուսակներում [CONTEXT_INFO](https://learn.microsoft.com/en-us/sql/t-sql/statements/set-context-info-transact-sql?view=sql-server-ver16) ֆունկցիայի միջոցով։

**Պարամետրեր**
* `value` - Սովորաբար նշվում է այն դասի անունը, որը կանչում է այս մեթոդը։ -->