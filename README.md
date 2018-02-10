# Monzo.Framework 🚀
[![Build status](https://ci.appveyor.com/api/projects/status/hdnrere1v5hgvrat?svg=true)](https://ci.appveyor.com/project/kiran94/monzo-framework)
[![AppVeyor tests](https://img.shields.io/appveyor/tests/kiran94/monzo-framework.svg)](https://ci.appveyor.com/project/kiran94/monzo-framework)
[![NuGet](https://img.shields.io/nuget/v/Monzo.Framework.svg)](https://www.nuget.org/packages/Monzo.Framework/)
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/4f86df636f854a16a94a165dd8c509bb)](https://www.codacy.com/app/kiran94/Monzo.Framework?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=kiran94/Monzo.Framework&amp;utm_campaign=Badge_Grade)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

Library to access the Monzo API via .NET.

- [Monzo.Framework 🚀](#monzoframework-%F0%9F%9A%80)
    - [Setup](#setup)
    - [Usage](#usage)
        - [Accounts](#accounts)
        - [Balance](#balance)
        - [Transactions](#transactions)
        - [Pots](#pots)

## Setup
1. `Install-Package Monzo.Framework`
2. Set up Environment variable:

```sh
export MONZO="<ACCESS_TOKEN>"
```

You can get your access token [here](https://developers.monzo.com/) if you have a Monzo Account.

## Usage
All services in this library make use of the `MonzoConfiguration` object. Each endpoint is also `awaitable`.

### Accounts
```cs
// Construct Account Service
var accountService = Monzo.Framework.Factory.CreateAccountService();

// Get Accounts (awaitable)
var accounts = await accountService.GetAccountsAsync();
```

### Balance
```cs
// Construct and retrieve Accounts and select one.
var accountService = Monzo.Framework.Factory.CreateAccountService();
var accounts = await accountService.GetAccountsAsync();
var account = accounts.AccountCollection.First();

// Construct Balance service and retrieve.
var balanceService = Monzo.Framework.Factory.CreateBalanceService();
var balance = await balanceService.GetBalanceAsync(account);
```

### Transactions
Transactions have multiple configurations. Each function can expand merchant information. You can currently retrieve:
- Single Transaction
- Multiple Transactions
- Multiple Transactions in a particular date period

```cs
// Retrieve Accounts and select one.
var accountService = Monzo.Framework.Factory.CreateAccountService();
var accounts = await accountService.GetAccountsAsync();
var account = accounts.AccountCollection.First();

// Construct transaction service.
var transactionService = Monzo.Framework.Factory.CreateTransactionService();

// Get Transactions for an account.
var transactionService = await transactionService.GetTransactionsAsync(account, false);

// Get a specific transaction by ID.
var transactionService = await transactionService.GetTransactionAsync("transaction_id", false);

// Get all transactions between 05/01/18 and 10/01/18 for an account.
var transactions = await transactionService.GetTransactionsByDateAsync(
    account,
    new DateTime(2018, 01, 05),
    new DateTime(2018, 01, 10), false);
```

### Pots
```cs
var potService = Monzo.Framework.Factory.CreatePotService();
var pots = await potService.GetPotsAsync()
```
