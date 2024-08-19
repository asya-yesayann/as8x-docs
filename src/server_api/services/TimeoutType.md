---
layout: page
title: "TimeoutType" 
tags: TimeoutType
---

Այս enum-ը նախատեսված է Sql հարցումների կատարման առավելագույն ժամանակի սահմանման համար։

```c#
public enum TimeoutType
{
    QueryTimeout,
    DsQueryTimeout
}
```

**Արժեքների բազմություն**

* `QueryTimeout` - Հարցումների կատարման առավելագույն ժամանակը՝ 30 վրկ։
* `DsQueryTimeout` - Տվյալների աղբյուրի հարցման կատարման առավելագույն ժամանակը՝ 300 վրկ։
