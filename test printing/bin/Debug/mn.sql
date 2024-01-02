-- Script Date: 12/31/2023 11:29 PM  - ErikEJ.SqlCeScripting version 3.5.2.95
-- Database information:
-- Database: C:\Users\Abdo\source\repos\test printing\test printing\bin\Debug\AbuFas.db
-- ServerVersion: 3.40.0
-- DatabaseSize: 40 KB
-- Created: 12/13/2023 4:59 PM

-- User Table information:
-- Number of tables: 5
-- BillData: -1 row(s)
-- Bills: -1 row(s)
-- DayStaticGrams: -1 row(s)
-- DaystaticMoney: -1 row(s)
-- IncomeOutcome: -1 row(s)

SELECT 1;
PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
CREATE TABLE [DaystaticMoney] (
  [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [Date] text NOT NULL
, [Type] bigint NOT NULL
, [Total] real NOT NULL
);
CREATE TABLE [IncomeOutcome] (
  [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [Name] text NULL
, [Date] text NOT NULL
, [Price] real NOT NULL
, [Notes] text NULL
, [IsIncome] bigint NOT NULL
, [MoneyId] bigint NULL
, CONSTRAINT [FK_IncomeOutcome_0_0] FOREIGN KEY ([MoneyId]) REFERENCES [DaystaticMoney] ([Id]) ON DELETE RESTRICT ON UPDATE NO ACTION
);
CREATE TABLE [DayStaticGrams] (
  [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [Type] text NULL
, [Date] text NOT NULL
, [Sell] real NOT NULL
, [Buy] real NOT NULL
, [Bouns] real NOT NULL
, [Minus] real NOT NULL
, [Damaged] real NOT NULL
);
CREATE TABLE [Bills] (
  [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [CustomerName] text NULL
, [Notes] text NULL
, [IsBuy] bigint NOT NULL
, [Total] real NOT NULL
, [Date] text NOT NULL
, [MoneyId] bigint NULL
, CONSTRAINT [FK_Bills_0_0] FOREIGN KEY ([MoneyId]) REFERENCES [DaystaticMoney] ([Id]) ON DELETE RESTRICT ON UPDATE NO ACTION
);
CREATE TABLE [BillData] (
  [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [Price] real NOT NULL
, [Weight] real NOT NULL
, [Type] real NOT NULL
, [Kyrat] bigint NOT NULL
, [Number] bigint NOT NULL
, [Name] text NULL
, [BillId] bigint NULL
, CONSTRAINT [FK_BillData_0_0] FOREIGN KEY ([BillId]) REFERENCES [Bills] ([Id]) ON DELETE RESTRICT ON UPDATE NO ACTION
);
INSERT INTO [DaystaticMoney] ([Id],[Date],[Type],[Total]) VALUES (
1,'2023-12-18 00:00:00',0,1002001);
INSERT INTO [DaystaticMoney] ([Id],[Date],[Type],[Total]) VALUES (
2,'2023-12-31 00:00:00',0,1002001);
INSERT INTO [DayStaticGrams] ([Id],[Type],[Date],[Sell],[Buy],[Bouns],[Minus],[Damaged]) VALUES (
1,NULL,'2023-12-18 00:00:00',0,200,0,0,0);
INSERT INTO [DayStaticGrams] ([Id],[Type],[Date],[Sell],[Buy],[Bouns],[Minus],[Damaged]) VALUES (
2,NULL,'2023-12-31 00:00:00',0,200,0,0,0);
CREATE INDEX [IncomeOutcome_IX_IncomeOutcome_MoneyId] ON [IncomeOutcome] ([MoneyId] ASC);
CREATE INDEX [Bills_IX_Bills_MoneyId] ON [Bills] ([MoneyId] ASC);
CREATE INDEX [BillData_IX_BillData_BillId] ON [BillData] ([BillId] ASC);
CREATE TRIGGER [fki_IncomeOutcome_MoneyId_DaystaticMoney_Id] BEFORE Insert ON [IncomeOutcome] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Insert on table IncomeOutcome violates foreign key constraint FK_IncomeOutcome_0_0') WHERE NEW.MoneyId IS NOT NULL AND(SELECT Id FROM DaystaticMoney WHERE  Id = NEW.MoneyId) IS NULL; END;
CREATE TRIGGER [fku_IncomeOutcome_MoneyId_DaystaticMoney_Id] BEFORE Update ON [IncomeOutcome] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Update on table IncomeOutcome violates foreign key constraint FK_IncomeOutcome_0_0') WHERE NEW.MoneyId IS NOT NULL AND(SELECT Id FROM DaystaticMoney WHERE  Id = NEW.MoneyId) IS NULL; END;
CREATE TRIGGER [fki_Bills_MoneyId_DaystaticMoney_Id] BEFORE Insert ON [Bills] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Insert on table Bills violates foreign key constraint FK_Bills_0_0') WHERE NEW.MoneyId IS NOT NULL AND(SELECT Id FROM DaystaticMoney WHERE  Id = NEW.MoneyId) IS NULL; END;
CREATE TRIGGER [fku_Bills_MoneyId_DaystaticMoney_Id] BEFORE Update ON [Bills] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Update on table Bills violates foreign key constraint FK_Bills_0_0') WHERE NEW.MoneyId IS NOT NULL AND(SELECT Id FROM DaystaticMoney WHERE  Id = NEW.MoneyId) IS NULL; END;
CREATE TRIGGER [fki_BillData_BillId_Bills_Id] BEFORE Insert ON [BillData] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Insert on table BillData violates foreign key constraint FK_BillData_0_0') WHERE NEW.BillId IS NOT NULL AND(SELECT Id FROM Bills WHERE  Id = NEW.BillId) IS NULL; END;
CREATE TRIGGER [fku_BillData_BillId_Bills_Id] BEFORE Update ON [BillData] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Update on table BillData violates foreign key constraint FK_BillData_0_0') WHERE NEW.BillId IS NOT NULL AND(SELECT Id FROM Bills WHERE  Id = NEW.BillId) IS NULL; END;
COMMIT;

