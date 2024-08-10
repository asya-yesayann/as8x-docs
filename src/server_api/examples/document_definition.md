---
layout: page
title: "Փաստաթղթի նկարագրության օրինակ 8X սերվիսում (DOCUMENT)" 
---

Այս օրինակում բերված են 4 ֆայլերը, որոնք ամբողջությամբ նկարագրում են փաստաթուղթը 8X համակարգում։

`UsrAccs.as` ֆայլի պարունակություն։ Ստեղծվում է 4X գործիքներով։
Պետք է գրված լինի ANSI կոդավորմամբ։

```as4x
DOCUMENT {
  NAME = UsrAccs;
  CAPTION = "Օգտագործողի հաշիվներ";
  ECAPTION = "User's accounts";
  PROCESSINGMODE = 8; '#DocProcessingMode2

  PAGE { CAPTION = "Ընդհանուր"; ECAPTION = "General";
    REKVIZIT {NAME = USERNAME; CAPTION = "Օգտագործողի անուն"; ECAPTION="User's name";         TYPE = C(20); };
    REKVIZIT {NAME = BRANCH;   CAPTION = "Մասնաճյուղ";        ECAPTION="Registration branch"; TYPE = C(10); };

    GRID {NAME = Accounts; CAPTION = "Հաշիվներ"; ECAPTION = "Accounts"; WIDTH = 13000; HEIGHT = 3000;
      COLUMN {NAME = ACCTYPE; CAPTION = "Տիպ"; ECAPTION = "Type"; TYPE = C(10);  };
      COLUMN {NAME = CODE;    CAPTION = "Կոդ"; ECAPTION = "Code"; TYPE = NP(16); };
    };

    MEMO {NAME = COMMENT; CAPTION = "Մեկնաբանություն"; ECAPTION = "Comment"; WIDTH = 7000; HEIGHT = 2300; };
  };
};
```

`UsrAccs.CodeGen.tt` ֆայլի պարունակություն։ Ստեղծվում է ձեռքով 8X սերվիսի պրոյեկտում կամ ընդլայնման պրոյեկտում։

```tt
<#@ template debug="false" hostspecific="true" language="C#" #>
<#@ assembly name="ArmSoft.AS8X.CodeGen" #>
<#@ import namespace="ArmSoft.AS8X.CodeGen" #>
<#@ output extension=".cs" encoding="utf-8" #>
<#
    string code = DocParser.Parse(
        configFilePath: this.Host.ResolvePath(@"..\CodeGen.xml"), 
        filename: @"\Users\UsrAccs.as", 
        docType: "UsrAccs", 
        namespaceName: "Bank");
#>
<#= code #>
```

`UsrAccs.CodeGen.cs` ֆայլի պարունակություն։ Ստեղծվում է ավտոմատ `.tt` ֆայլի վրա `Run Custom Tool` գործողությամբ։

```c#
// Ավտոմատ գեներացված է՝ սկիզբ
using ArmSoft.AS8X.Core;
using ArmSoft.AS8X.Core.Document;
using ArmSoft.AS8X.Common.Extensions;

namespace ArmSoft.AS8X.Bank
{
    [Document("UsrAccs")]
    public partial class UsrAccs : Document
    {
        public partial class AccountsRow : GridRow
        {
            /// <summary>
            /// Տիպ
            /// </summary>
            public string ACCTYPE
            {
                get { return (string)this[nameof(this.ACCTYPE)]; }
                set { this[nameof(this.ACCTYPE)] = value; }
            }

            /// <summary>
            /// Կոդ
            /// </summary>
            public decimal CODE
            {
                get { return (decimal)this[nameof(this.CODE)]; }
                set { this[nameof(this.CODE)] = value; }
            }

        }

        /// <summary>
        /// Հաշիվներ
        /// </summary>
        public Grid<AccountsRow> Accounts
        {
            get
            {
                return (Grid<AccountsRow>)this.Grids[nameof(this.Accounts)];
            }
        }


        // Fields
        /// <summary>
        /// Օգտագործողի անուն
        /// </summary>
        public string USERNAME
        {
            get { return (string)this[nameof(this.USERNAME)]; }
            set { this[nameof(this.USERNAME)] = value; }
        }

        /// <summary>
        /// Մասնաճյուղ
        /// </summary>
        public string BRANCH
        {
            get { return (string)this[nameof(this.BRANCH)]; }
            set { this[nameof(this.BRANCH)] = value; }
        }

        // Memos
        /// <summary>
        /// Մեկնաբանություն
        /// </summary>
        public string COMMENT
        {
            get { return GetMemo(nameof(this.COMMENT)); }
            set { SetMemo(nameof(this.COMMENT), value); }
        }
    }
}
// Ավտոմատ գեներացված է՝ վերջ
```

`UsrAccs.cs` ֆայլի պարունակություն։ Ստեղծվում է ձեռքով 8X սերվիսի պրոյեկտում կամ ընդլայնման պրոյեկտում։

```c#
using System;

namespace ArmSoft.AS8X.Bank;

public partial class UsrAccs
{
    private readonly IParametersService parametersService;

    public UserAccounts(IParametersService parameterService, IServiceProvider serviceProvider) : base(serviceProvider)
    {
        this.parametersService = parameterService;

    }

    public override Task Validate(ValidateEventArgs args)
    {
        if (this.Accounts.RowCount == 0)
        {
            throw new Exception("Օգտագործողին հաշիվներ կցված չեն".ToArmenianANSI());
        }
        return Task.CompletedTask;
    }

    public override async Task Action(ActionEventArgs args)
    {
        if (string.IsNullOrWhiteSpace(this.BRANCH))
        {
            this.BRANCH = await this.parametersService.DefaultBranch();
        }
    }

    public override Task Folders(FoldersEventArgs args)
    {
        var folderElement = new FolderElement()
        {
            FolderId = "UserAccounts",
            Status = FolderStatus.Edit,
            Key = this.USERNAME,
            Comment = this.Description.ArmenianCaption,
            EComment = this.Description.EnglishCaption,
            Spec = this.USERNAME.LeftAlign(20) + this.BRANCH.LeftAlign(50)
        };
        this.DocumentService.StoreInFolder(this, folderElement);
        return Task.CompletedTask;
    }

    public override async Task Delete(DeleteEventArgs args)
    {
        bool isDeletionAllowed = await this.parametersService.GetBooleanValue("DELETEALIENDOCS");
        if (!isDeletionAllowed)
        {
            throw new Exception("Փաստաթուղթը հեռացնելու իրավասություն չունեք".ToArmenianANSI());
        }
    }
}
```
