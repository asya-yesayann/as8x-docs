using System;
using System.Threading.Tasks;
using ArmSoft.AS8X.Common.Extensions;
using ArmSoft.AS8X.Core;
using ArmSoft.AS8X.Core.Document;
using ArmSoft.AS8X.Core.Folder;

namespace ArmSoft.AS8X.Bank.General.AccBal.DOCS
{
    [Document("UsrAccs")]
    public class UserAccounts : Document
    {
        public class AccountingRow : GridRow
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
            public int CODE
            {
                get { return (int)this[nameof(this.CODE)]; }
                set { this[nameof(this.CODE)] = value; }
            }

            /// <summary>
            /// Բացման ամսաթիվ
            /// </summary>
            public DateTime? OPENDATE
            {
                get { return (DateTime?)this[nameof(this.OPENDATE)]; }
                set { this[nameof(this.OPENDATE)] = value; }
            }

        }

        /// <summary>
        /// Օգտագործողի հաշիվներ
        /// </summary>
        public Grid<AccountingRow> Accountings
        {
            get
            {
                return (Grid<AccountingRow>)this.Grids[nameof(this.Accountings)];
            }
        }

        /// <summary>
        /// Օգտագործողի անվանում
        /// </summary>
        public string NAME
        {
            get { return (string)this[nameof(this.NAME)]; }
            set { this[nameof(this.NAME)] = value; }
        }

        /// <summary>
        /// Օգտագործողի ներքին նույնականացման համար
        /// </summary>
        public short USERID
        {
            get { return (short)this[nameof(this.USERID)]; }
            set { this[nameof(this.USERID)] = value; }
        }

        /// <summary>
        /// Գրանցման մասնաճյուղ
        /// </summary>
        public string BRANCH
        {
            get { return (string)this[nameof(this.BRANCH)]; }
            set { this[nameof(this.BRANCH)] = value; }
        }

        /// <summary>
        /// Մեկնաբանություն
        /// </summary>
        public string COMMENT
        {
            get { return GetMemo(nameof(this.COMMENT)); }
            set { SetMemo(nameof(this.COMMENT), value); }
        }

        private readonly IParametersService parametersService;

        public UserAccounts(IParametersService parameterService, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            this.parametersService = parameterService;
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
                Key = this.ISN.ToString(),
                Comment = this.Description.ArmenianCaption,
                EComment = this.Description.EnglishCaption,
                Spec = this.NAME.LeftAlign(50) + this.USERID.ToString().LeftAlign(20)
            };
            this.DocumentService.StoreInFolder(this, folderElement);
            return Task.CompletedTask;
        }

        public override Task Validate(ValidateEventArgs args)
        {
            if (this.Accountings.RowCount == 0)
            {
                throw new Exception("Օգտագործողին հաշիվներ կցված չեն");
            }
            return Task.CompletedTask;
        }

        public override async Task Delete(DeleteEventArgs args)
        {
            var isDeletionAllowed = await this.parametersService.GetBooleanValue("DELETEALIENDOCS");
            if (!isDeletionAllowed)
            {
                throw new Exception("Փաստաթուղթը հեռացնելու իրավասություն չունեք");
            }
        }
    }
}
