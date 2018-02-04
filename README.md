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
// Create configuration object.
var configuration = new MonzoConfiguration();

// Create Account service and pass config.
var accountService = new AccountService(configuration);

// Get Accounts (awaitable)
var accounts = await accountService.GetAccountsAsync();
```

### Balance
```cs
// Create configuration object.
var configuration = new MonzoConfiguration();

// Retrieve Accounts and select one.
var accountService = new AccountService(configuration);
var accounts = await accountService.GetAccountsAsync();
var account = accounts.Result.AccountCollection.First();

// Create Balance service and retrieve.
var balanceservice = new BalanceService(configuration);
var balance = await balanceservice.GetBalanceAsync(account);
```

### Transactions

Transactions have multiple configurations. Each function can expand merchant information. You can currently retrieve:
- Single Transaction
- Multiple Transactions
- Multiple Transactions in a particular date period

```cs
// Retrieve Accounts and select one.
var accountService = new AccountService(configuration);
var accounts = await accountService.GetAccountsAsync();
var account = accounts.Result.AccountCollection.First();

// Construct transaction service.
var transactionService = new TransactionService(configuration);

// Get Transactions for an account.
var transactions = await transactionService.GetTransactionsAsync(account, false);

// Get all transactions for an account.
var transactions = await transactionService.GetTransactionAsync("transaction_id", false);

// Get all transactions between 05/01/18 and 10/01/18 for an account.
var transactions = await transactionService.GetTransactionsByDateAsync(
    account,
    new DateTime(2018, 01, 05),
    new DateTime(2018, 01, 10), false);
```

### Pots
```cs
var potservice = new PotService(configuration);
var pots = potservice.GetPotsAsync()
```
