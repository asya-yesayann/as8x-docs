---
title: IOlapDBService.GetApproximateServerDate() մեթոդ
---

```c#
public Task<DateTime> GetApproximateServerDate();
```

Վերադարձնում է SQL սերվերի ընթացիկ ամսաթիվը/ժամը որոշակի շեղման հավանականությամբ։

Ավելի արագ է աշխատում քան [GetServerDate](GetServerDate.md), քանզի աշխատում է ամեն անգամ SQL չկատարելու սկզբունքով։