﻿UPDATE sjbrett_AdvAcct.SL_PL_NL_DETAIL 
SET
  DET_NETT = 0 -- DET_NETT - DOUBLE
 ,DET_VAT = 0 -- DET_VAT - DOUBLE
 ,DET_VATCODE = '' -- DET_VATCODE - VARCHAR(4)
 ,DET_GROSS = 0 -- DET_GROSS - DOUBLE
 ,DET_UNALLOCATED = 0 -- DET_UNALLOCATED - DOUBLE
 ,DET_BATCH_FLAG = 0 -- DET_BATCH_FLAG - TINYINT(4)
 ,DET_RECUR_FLAG = 0 -- DET_RECUR_FLAG - TINYINT(4)
 ,DET_BATCH_REF = '' -- DET_BATCH_REF - VARCHAR(10)
 ,DET_ARCHIVE_FLG = 0 -- DET_ARCHIVE_FLG - TINYINT(4)
 ,DET_ORIGIN = '' -- DET_ORIGIN - VARCHAR(3)
 ,DET_LEDGER = '' -- DET_LEDGER - VARCHAR(2)
 ,DET_TYPE = '' -- DET_TYPE - VARCHAR(3)
 ,DET_DESCRIPTION = '' -- DET_DESCRIPTION - VARCHAR(240)
 ,DET_HEADER_REF = '' -- DET_HEADER_REF - VARCHAR(26)
 ,DET_JNL_LINEREF = '' -- DET_JNL_LINEREF - VARCHAR(10)
 ,DET_PL_INTERNAL = 0 -- DET_PL_INTERNAL - DOUBLE
 ,DET_DATE = NOW() -- DET_DATE - DATETIME
 ,DET_TAX_SORT = '' -- DET_TAX_SORT - VARCHAR(4)
 ,DET_CURR_TAX = 0 -- DET_CURR_TAX - DOUBLE
 ,DET_TAX_WITHHLD = 0 -- DET_TAX_WITHHLD - DOUBLE
 ,DET_PL_ACQ_TAX = 0 -- DET_PL_ACQ_TAX - DOUBLE
 ,DET_CURR_CODE = '' -- DET_CURR_CODE - VARCHAR(4)
 ,DET_CURR_RATE = 0 -- DET_CURR_RATE - DOUBLE
 ,DET_CURR_NETT = 0 -- DET_CURR_NETT - DOUBLE
 ,DET_CURR_RTEFLG = 0 -- DET_CURR_RTEFLG - TINYINT(4)
 ,DET_CURR_UNALOC = 0 -- DET_CURR_UNALOC - DOUBLE
 ,DET_CURR_L_DISC = 0 -- DET_CURR_L_DISC - DOUBLE
 ,DET_CURR_T_DISC = 0 -- DET_CURR_T_DISC - DOUBLE
 ,DET_IMPEXP_CODE = '' -- DET_IMPEXP_CODE - VARCHAR(1)
 ,DET_COUNTRY_CDE = '' -- DET_COUNTRY_CDE - VARCHAR(4)
 ,DET_ECVAT_TYPE = '' -- DET_ECVAT_TYPE - VARCHAR(1)
 ,DET_L_DISCOUNT = 0 -- DET_L_DISCOUNT - DOUBLE
 ,DET_T_DISCOUNT = 0 -- DET_T_DISCOUNT - DOUBLE
 ,DET_COSTPRICE = 0 -- DET_COSTPRICE - DOUBLE
 ,DET_PERIOD_SORT = 0 -- DET_PERIOD_SORT - INT(11)
 ,DET_PERIODNUMBR = 0 -- DET_PERIODNUMBR - TINYINT(4)
 ,DET_YEAR = '' -- DET_YEAR - VARCHAR(1)
 ,DET_RECONCILED = 0 -- DET_RECONCILED - TINYINT(4)
 ,DET_NOM_PERIOD = 0 -- DET_NOM_PERIOD - TINYINT(4)
 ,DET_NOM_YEAR = '' -- DET_NOM_YEAR - VARCHAR(1)
 ,DET_NOM_PERSORT = 0 -- DET_NOM_PERSORT - INT(11)
 ,DET_RECON_REF = '' -- DET_RECON_REF - VARCHAR(10)
 ,DT_RECON_ORDER = 0 -- DT_RECON_ORDER - DOUBLE
 ,DET_UNIT_PRICE = 0 -- DET_UNIT_PRICE - DOUBLE
 ,DET_QUANTITY = 0 -- DET_QUANTITY - DOUBLE
 ,DET_UNT_PRICE_C = 0 -- DET_UNT_PRICE_C - DOUBLE
 ,DET_UNIT_QTY = 0 -- DET_UNIT_QTY - DOUBLE
 ,DET_USER_PUTIN = '' -- DET_USER_PUTIN - VARCHAR(4)
 ,DET_DATE_PUTIN = NOW() -- DET_DATE_PUTIN - DATETIME
 ,DET_HEADER_KEY = '' -- DET_HEADER_KEY - VARCHAR(20)
 ,DET_BATCH_POSTD = 0 -- DET_BATCH_POSTD - TINYINT(4)
 ,DET_SERIALNO = '' -- DET_SERIALNO - VARCHAR(40)
 ,DET_STKSORTKEY1 = '' -- DET_STKSORTKEY1 - VARCHAR(20)
 ,DET_PRICE_CODE = '' -- DET_PRICE_CODE - VARCHAR(16)
 ,DET_NOMINALDR = '' -- DET_NOMINALDR - VARCHAR(25)
 ,DET_NOMINALCR = '' -- DET_NOMINALCR - VARCHAR(25)
 ,DET_NOMINALVAT = '' -- DET_NOMINALVAT - VARCHAR(25)
 ,DET_STOCK_CODE = '' -- DET_STOCK_CODE - VARCHAR(25)
 ,DET_ACCOUNT = '' -- DET_ACCOUNT - VARCHAR(10)
 ,DET_ANALYSIS = '' -- DET_ANALYSIS - VARCHAR(25)
 ,DET_COSTHEADER = '' -- DET_COSTHEADER - VARCHAR(10)
 ,DET_COSTCENTRE = '' -- DET_COSTCENTRE - VARCHAR(10)
 ,DET_ANALTYPE = '' -- DET_ANALTYPE - VARCHAR(1)
 ,DET_PRIMARY = 0 -- DET_PRIMARY - DOUBLE NOT NULL
 ,DET_EC_T_NATURE = '' -- DET_EC_T_NATURE - VARCHAR(2)
 ,DET_SUB_AUDIT_NO = 0 -- DET_SUB_AUDIT_NO - DOUBLE
 ,DET_SUB_LEDGER = '' -- DET_SUB_LEDGER - VARCHAR(10)
 ,DET_VAT_RULES = 0 -- DET_VAT_RULES - TINYINT(4)
 ,DET_VATNONDEDUCT = 0 -- DET_VATNONDEDUCT - DOUBLE
 ,DET_STKSORTKEY2 = '' -- DET_STKSORTKEY2 - VARCHAR(20)
 ,DET_STKSORTKEY3 = '' -- DET_STKSORTKEY3 - VARCHAR(20)
 ,DET_STKSORTKEY = '' -- DET_STKSORTKEY - VARCHAR(20)
 ,DET_LANDED_COST = '' -- DET_LANDED_COST - VARCHAR(1)
 ,DET_DIMENSION1 = '' -- DET_DIMENSION1 - VARCHAR(20)
 ,DET_DIMENSION2 = '' -- DET_DIMENSION2 - VARCHAR(20)
 ,DET_DIMENSION3 = '' -- DET_DIMENSION3 - VARCHAR(20)
 ,DET_CHEQUE_PAYEE = '' -- DET_CHEQUE_PAYEE - VARCHAR(40)
 ,DET_NETT_BASE2 = 0 -- DET_NETT_BASE2 - DOUBLE
 ,DET_VAT_BASE2 = 0 -- DET_VAT_BASE2 - DOUBLE
 ,DET_GROSS_BASE2 = 0 -- DET_GROSS_BASE2 - DOUBLE
 ,DET_L_DISC_BASE2 = 0 -- DET_L_DISC_BASE2 - DOUBLE
 ,DET_T_DISC_BASE2 = 0 -- DET_T_DISC_BASE2 - DOUBLE
 ,DET_BASE2_RATE = 0 -- DET_BASE2_RATE - DOUBLE
 ,DET_TRI_RATE1 = 0 -- DET_TRI_RATE1 - DOUBLE
 ,DET_BASE2_RATECHNG = 0 -- DET_BASE2_RATECHNG - TINYINT(4)
 ,DET_TRI_RATECHNG1 = 0 -- DET_TRI_RATECHNG1 - TINYINT(4)
 ,DET_COSTPRICE_BASE2 = 0 -- DET_COSTPRICE_BASE2 - DOUBLE
 ,DET_UNIT_PRICE_BASE2 = 0 -- DET_UNIT_PRICE_BASE2 - DOUBLE
 ,DET_TAX_WITHHLD_BASE2 = 0 -- DET_TAX_WITHHLD_BASE2 - DOUBLE
 ,DET_PL_ACQUISTN_BASE2 = 0 -- DET_PL_ACQUISTN_BASE2 - DOUBLE
 ,DET_CURR_GROSS = 0 -- DET_CURR_GROSS - DOUBLE
 ,DET_TRI_RATE2 = 0 -- DET_TRI_RATE2 - DOUBLE
 ,DET_TRI_RATECHNG2 = 0 -- DET_TRI_RATECHNG2 - TINYINT(4)
 ,DET_NLCONTRA = '' -- DET_NLCONTRA - VARCHAR(25)
 ,DET_HEADER_REF2 = '' -- DET_HEADER_REF2 - VARCHAR(10)
 ,DET_SLPL_PRIMARY = '' -- DET_SLPL_PRIMARY - VARCHAR(20)
 ,DET_SRV_STATUS = 0 -- DET_SRV_STATUS - TINYINT(4)
 ,DET_ORDER_LINK = 0 -- DET_ORDER_LINK - INT(11)
 ,DET_SOURCE = '' -- DET_SOURCE - VARCHAR(1)
 ,DET_VAT_RETURN_PRIMARY = 0 -- DET_VAT_RETURN_PRIMARY - INT(11)
 ,DET_DELIVERY_ADDRESS = '' -- DET_DELIVERY_ADDRESS - VARCHAR(16)
 ,DET_POSTING_NO = 0 -- DET_POSTING_NO - INT(11)
 ,DET_REVERSE_STATUS = 0 -- DET_REVERSE_STATUS - TINYINT(4)
 ,DET_MOVEMENT_LINK = 0 -- DET_MOVEMENT_LINK - INT(11)
 ,DET_NOM_YEAR_LINK = 0 -- DET_NOM_YEAR_LINK - INT(11)
 ,DET_VAT_RATE = 0 -- DET_VAT_RATE - DOUBLE
WHERE
<Search Conditions,,>