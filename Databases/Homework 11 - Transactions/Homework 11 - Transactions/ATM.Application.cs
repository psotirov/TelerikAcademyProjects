using System;
using System.Linq;
using System.Transactions;

namespace Homework_11___Transactions
{
    class ATM_Application
    {
        static void Main()
        {
            // Task 1
            /*
                USE [ATM]
                GO
                -- ****** Object:  Table [dbo].[TransactionsHistory]    Script Date: 07/23/2013 01:08:36 ******
                SET ANSI_NULLS ON
                GO
                SET QUOTED_IDENTIFIER ON
                GO
                CREATE TABLE [dbo].[TransactionsHistory](
	                [Id] [int] IDENTITY(1,1) NOT NULL,
	                [CardNumber] [nchar](10) NOT NULL,
	                [TransactionDate] [date] NOT NULL,
	                [Ammount] [money] NOT NULL,
                    CONSTRAINT [PK_TransactionsHistory] PRIMARY KEY CLUSTERED 
                (
	                [Id] ASC
                )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
                ) ON [PRIMARY]
                GO
                -- /****** Object:  Table [dbo].[CardAccounts]    Script Date: 07/23/2013 01:08:36 ******
                SET ANSI_NULLS ON
                GO
                SET QUOTED_IDENTIFIER ON
                GO
                CREATE TABLE [dbo].[CardAccounts](
	                [Id] [int] IDENTITY(1,1) NOT NULL,
	                [CardNumber] [nchar](10) NOT NULL,
	                [CardPIN] [nchar](4) NOT NULL,
	                [CardCash] [money] NOT NULL,
                    CONSTRAINT [PK_CardAccounts] PRIMARY KEY CLUSTERED 
                (
	                [Id] ASC
                )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
                ) ON [PRIMARY]
                GO
            */

            // Task 2
            using (var ctx = new ATMEntities())
            {
                Console.Write("Please select card (enter card number): ");
                string cardNr = Console.ReadLine().Trim();
                var card = ctx.CardAccounts.Where(c => c.CardNumber == cardNr).ToList();
                if (card.Count == 0)
                {
                    Console.WriteLine("Wrong Card Number");
                    return;
                }
                decimal ammount = 0;

                using (var tran = new TransactionScope(TransactionScopeOption.RequiresNew,
                    new TransactionOptions() { IsolationLevel = IsolationLevel.RepeatableRead}))
                {
                    Console.Write("Please enter desired sum to withdraw: ");
                    ammount = decimal.Parse(Console.ReadLine().Trim());
                    if (card[0].CardCash < ammount)
                    {
                        Console.WriteLine("Insufficient ballance into the account");
                        return;
                    } 
                    
                    Console.Write("Please enter card PIN (4 digits): ");
                    string pin = Console.ReadLine().Trim();
                    if (card[0].CardPIN != pin)
                    {
                        Console.WriteLine("Wrong PIN");
                        return;
                    }

                    card[0].CardCash -= ammount;
                    ctx.SaveChanges();
                    Console.WriteLine("Please take the ammount of " + ammount);
                    tran.Complete();
                }

                // Task 3
                if (ammount > 0)
                {
                    using (var tran = new TransactionScope(TransactionScopeOption.RequiresNew,
                        new TransactionOptions() { IsolationLevel = IsolationLevel.Serializable }))
                    {
                        Console.Write("Updating your transaction history...");
                        var history = new TransactionsHistory();
                        history.CardNumber = card[0].CardNumber;
                        history.TransactionDate = DateTime.Now;
                        history.Ammount = ammount;
                        ctx.TransactionsHistories.Add(history);
                        ctx.SaveChanges();
                        tran.Complete();
                    }

                    Console.WriteLine("Done.");
                }
            }
        }
    }
}
