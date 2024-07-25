using ArmSoft.AS8X.Core.Document;

namespace ArmSoft.AS8X.Bank.General.AccBal.DOCS
{
    [Document("UsrAccs")]
    public partial class UserAccounts
    {
        public class AccountRow : GridRow
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
        }

        /// <summary>
        /// Հաշիվներ
        /// </summary>
        public Grid<AccountRow> Accounts
        {
            get
            {
                return (Grid<AccountRow>)this.Grids[nameof(this.Accounts)];
            }
        }

        /// <summary>
        /// Օգտագործողի անուն
        /// </summary>
        public string USERNAME
        {
            get { return (string)this[nameof(this.USERNAME)]; }
            set { this[nameof(this.USERNAME)] = value; }
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
    }
}
