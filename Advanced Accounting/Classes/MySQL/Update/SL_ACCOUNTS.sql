﻿UPDATE sjbrett_AdvAcct.SL_ACCOUNTS 
SET
  CUCODE = '' -- CUCODE - VARCHAR(10)
 ,CUNAME = '' -- CUNAME - VARCHAR(40)
 ,CUADDRESS = '' -- CUADDRESS - VARCHAR(160)
 ,CUPOSTCODE = '' -- CUPOSTCODE - VARCHAR(12)
 ,CUPHONE = '' -- CUPHONE - VARCHAR(20)
 ,CUPHONE2 = '' -- CUPHONE2 - VARCHAR(20)
 ,CUFAX = '' -- CUFAX - VARCHAR(20)
 ,CUPROSCODE = '' -- CUPROSCODE - VARCHAR(10)
 ,CUCONTACT = '' -- CUCONTACT - VARCHAR(30)
 ,CUSALUTE = '' -- CUSALUTE - VARCHAR(20)
 ,CU_PRO_CONDATE = NOW() -- CU_PRO_CONDATE - DATETIME
 ,CU_EXPORT_CODE = '' -- CU_EXPORT_CODE - VARCHAR(1)
 ,CU_COUNTRY_CODE = '' -- CU_COUNTRY_CODE - VARCHAR(4)
 ,CU_VAT_REG_NO = '' -- CU_VAT_REG_NO - VARCHAR(21)
 ,CU_EC_DELIVERY = '' -- CU_EC_DELIVERY - VARCHAR(3)
 ,CU_EC_T_NATURE = '' -- CU_EC_T_NATURE - VARCHAR(2)
 ,CU_EC_T_MODE = '' -- CU_EC_T_MODE - VARCHAR(1)
 ,CUBALANCE = 0 -- CUBALANCE - DOUBLE
 ,CUBALANCE_C = 0 -- CUBALANCE_C - DOUBLE
 ,CUAGED_1 = 0 -- CUAGED_1 - DOUBLE
 ,CUAGED_2 = 0 -- CUAGED_2 - DOUBLE
 ,CUAGED_3 = 0 -- CUAGED_3 - DOUBLE
 ,CUAGED_4 = 0 -- CUAGED_4 - DOUBLE
 ,CUAGED_UNALLOC = 0 -- CUAGED_UNALLOC - DOUBLE
 ,CUSORT = '' -- CUSORT - VARCHAR(20)
 ,CUUSER1 = '' -- CUUSER1 - VARCHAR(20)
 ,CUUSER2 = '' -- CUUSER2 - VARCHAR(20)
 ,CUUSER3 = '' -- CUUSER3 - VARCHAR(20)
 ,CUTURNOVERPTD = 0 -- CUTURNOVERPTD - DOUBLE
 ,CUTURNOVR_L1 = 0 -- CUTURNOVR_L1 - DOUBLE
 ,CUTURNOVR_L2 = 0 -- CUTURNOVR_L2 - DOUBLE
 ,CUTURNOVR_L3 = 0 -- CUTURNOVR_L3 - DOUBLE
 ,CUTURNOVR_L4 = 0 -- CUTURNOVR_L4 - DOUBLE
 ,CUTURNOVR_L5 = 0 -- CUTURNOVR_L5 - DOUBLE
 ,CUTURNOVR_L6 = 0 -- CUTURNOVR_L6 - DOUBLE
 ,CUTURNOVR_L7 = 0 -- CUTURNOVR_L7 - DOUBLE
 ,CUTURNOVR_L8 = 0 -- CUTURNOVR_L8 - DOUBLE
 ,CUTURNOVR_L9 = 0 -- CUTURNOVR_L9 - DOUBLE
 ,CUTURNOVR_L10 = 0 -- CUTURNOVR_L10 - DOUBLE
 ,CUTURNOVR_L11 = 0 -- CUTURNOVR_L11 - DOUBLE
 ,CUTURNOVR_L12 = 0 -- CUTURNOVR_L12 - DOUBLE
 ,CUTURNOVR_L13 = 0 -- CUTURNOVR_L13 - DOUBLE
 ,CUTURNOVR_C1 = 0 -- CUTURNOVR_C1 - DOUBLE
 ,CUTURNOVR_C2 = 0 -- CUTURNOVR_C2 - DOUBLE
 ,CUTURNOVR_C3 = 0 -- CUTURNOVR_C3 - DOUBLE
 ,CUTURNOVR_C4 = 0 -- CUTURNOVR_C4 - DOUBLE
 ,CUTURNOVR_C5 = 0 -- CUTURNOVR_C5 - DOUBLE
 ,CUTURNOVR_C6 = 0 -- CUTURNOVR_C6 - DOUBLE
 ,CUTURNOVR_C7 = 0 -- CUTURNOVR_C7 - DOUBLE
 ,CUTURNOVR_C8 = 0 -- CUTURNOVR_C8 - DOUBLE
 ,CUTURNOVR_C9 = 0 -- CUTURNOVR_C9 - DOUBLE
 ,CUTURNOVR_C10 = 0 -- CUTURNOVR_C10 - DOUBLE
 ,CUTURNOVR_C11 = 0 -- CUTURNOVR_C11 - DOUBLE
 ,CUTURNOVR_C12 = 0 -- CUTURNOVR_C12 - DOUBLE
 ,CUTURNOVR_C13 = 0 -- CUTURNOVR_C13 - DOUBLE
 ,CUTURNOVR_O1 = 0 -- CUTURNOVR_O1 - DOUBLE
 ,CUTURNOVR_O2 = 0 -- CUTURNOVR_O2 - DOUBLE
 ,CUTURNOVR_O3 = 0 -- CUTURNOVR_O3 - DOUBLE
 ,CUTURNOVR_O4 = 0 -- CUTURNOVR_O4 - DOUBLE
 ,CUTURNOVR_O5 = 0 -- CUTURNOVR_O5 - DOUBLE
 ,CUTURNOVR_O6 = 0 -- CUTURNOVR_O6 - DOUBLE
 ,CUTURNOVR_O7 = 0 -- CUTURNOVR_O7 - DOUBLE
 ,CUTURNOVR_O8 = 0 -- CUTURNOVR_O8 - DOUBLE
 ,CUTURNOVR_O9 = 0 -- CUTURNOVR_O9 - DOUBLE
 ,CUTURNOVR_O10 = 0 -- CUTURNOVR_O10 - DOUBLE
 ,CUTURNOVR_O11 = 0 -- CUTURNOVR_O11 - DOUBLE
 ,CUTURNOVR_O12 = 0 -- CUTURNOVR_O12 - DOUBLE
 ,CUTURNOVR_O13 = 0 -- CUTURNOVR_O13 - DOUBLE
 ,CUTURNOVERYTD = 0 -- CUTURNOVERYTD - DOUBLE
 ,CUCURRENCYCODE = '' -- CUCURRENCYCODE - VARCHAR(6)
 ,CUTURNOVR_L1_C = 0 -- CUTURNOVR_L1_C - DOUBLE
 ,CUTURNOVR_L2_C = 0 -- CUTURNOVR_L2_C - DOUBLE
 ,CUTURNOVR_L3_C = 0 -- CUTURNOVR_L3_C - DOUBLE
 ,CUTURNOVR_L4_C = 0 -- CUTURNOVR_L4_C - DOUBLE
 ,CUTURNOVR_L5_C = 0 -- CUTURNOVR_L5_C - DOUBLE
 ,CUTURNOVR_L6_C = 0 -- CUTURNOVR_L6_C - DOUBLE
 ,CUTURNOVR_L7_C = 0 -- CUTURNOVR_L7_C - DOUBLE
 ,CUTURNOVR_L8_C = 0 -- CUTURNOVR_L8_C - DOUBLE
 ,CUTURNOVR_L9_C = 0 -- CUTURNOVR_L9_C - DOUBLE
 ,CUTURNOVR_L10_C = 0 -- CUTURNOVR_L10_C - DOUBLE
 ,CUTURNOVR_L11_C = 0 -- CUTURNOVR_L11_C - DOUBLE
 ,CUTURNOVR_L12_C = 0 -- CUTURNOVR_L12_C - DOUBLE
 ,CUTURNOVR_L13_C = 0 -- CUTURNOVR_L13_C - DOUBLE
 ,CUTURNOVR_C1_C = 0 -- CUTURNOVR_C1_C - DOUBLE
 ,CUTURNOVR_C2_C = 0 -- CUTURNOVR_C2_C - DOUBLE
 ,CUTURNOVR_C3_C = 0 -- CUTURNOVR_C3_C - DOUBLE
 ,CUTURNOVR_C4_C = 0 -- CUTURNOVR_C4_C - DOUBLE
 ,CUTURNOVR_C5_C = 0 -- CUTURNOVR_C5_C - DOUBLE
 ,CUTURNOVR_C6_C = 0 -- CUTURNOVR_C6_C - DOUBLE
 ,CUTURNOVR_C7_C = 0 -- CUTURNOVR_C7_C - DOUBLE
 ,CUTURNOVR_C8_C = 0 -- CUTURNOVR_C8_C - DOUBLE
 ,CUTURNOVR_C9_C = 0 -- CUTURNOVR_C9_C - DOUBLE
 ,CUTURNOVR_C10_C = 0 -- CUTURNOVR_C10_C - DOUBLE
 ,CUTURNOVR_C11_C = 0 -- CUTURNOVR_C11_C - DOUBLE
 ,CUTURNOVR_C12_C = 0 -- CUTURNOVR_C12_C - DOUBLE
 ,CUTURNOVR_C13_C = 0 -- CUTURNOVR_C13_C - DOUBLE
 ,CUTURNOVR_O1_C = 0 -- CUTURNOVR_O1_C - DOUBLE
 ,CUTURNOVR_O2_C = 0 -- CUTURNOVR_O2_C - DOUBLE
 ,CUTURNOVR_O3_C = 0 -- CUTURNOVR_O3_C - DOUBLE
 ,CUTURNOVR_O4_C = 0 -- CUTURNOVR_O4_C - DOUBLE
 ,CUTURNOVR_O5_C = 0 -- CUTURNOVR_O5_C - DOUBLE
 ,CUTURNOVR_O6_C = 0 -- CUTURNOVR_O6_C - DOUBLE
 ,CUTURNOVR_O7_C = 0 -- CUTURNOVR_O7_C - DOUBLE
 ,CUTURNOVR_O8_C = 0 -- CUTURNOVR_O8_C - DOUBLE
 ,CUTURNOVR_O9_C = 0 -- CUTURNOVR_O9_C - DOUBLE
 ,CUTURNOVR_O10_C = 0 -- CUTURNOVR_O10_C - DOUBLE
 ,CUTURNOVR_O11_C = 0 -- CUTURNOVR_O11_C - DOUBLE
 ,CUTURNOVR_O12_C = 0 -- CUTURNOVR_O12_C - DOUBLE
 ,CUTURNOVR_O13_C = 0 -- CUTURNOVR_O13_C - DOUBLE
 ,CUTURNOVR_YTD_C = 0 -- CUTURNOVR_YTD_C - DOUBLE
 ,CUTURNOVR_PTD_C = 0 -- CUTURNOVR_PTD_C - DOUBLE
 ,CU_COSTVAL_1 = 0 -- CU_COSTVAL_1 - DOUBLE
 ,CU_COSTVAL_2 = 0 -- CU_COSTVAL_2 - DOUBLE
 ,CU_COSTVAL_3 = 0 -- CU_COSTVAL_3 - DOUBLE
 ,CU_COSTVAL_4 = 0 -- CU_COSTVAL_4 - DOUBLE
 ,CU_COSTVAL_5 = 0 -- CU_COSTVAL_5 - DOUBLE
 ,CU_COSTVAL_6 = 0 -- CU_COSTVAL_6 - DOUBLE
 ,CU_COSTVAL_7 = 0 -- CU_COSTVAL_7 - DOUBLE
 ,CU_COSTVAL_8 = 0 -- CU_COSTVAL_8 - DOUBLE
 ,CU_COSTVAL_9 = 0 -- CU_COSTVAL_9 - DOUBLE
 ,CU_COSTVAL_10 = 0 -- CU_COSTVAL_10 - DOUBLE
 ,CU_COSTVAL_11 = 0 -- CU_COSTVAL_11 - DOUBLE
 ,CU_COSTVAL_12 = 0 -- CU_COSTVAL_12 - DOUBLE
 ,CU_COSTVAL_13 = 0 -- CU_COSTVAL_13 - DOUBLE
 ,CU_SALEVAL_1 = 0 -- CU_SALEVAL_1 - DOUBLE
 ,CU_SALEVAL_2 = 0 -- CU_SALEVAL_2 - DOUBLE
 ,CU_SALEVAL_3 = 0 -- CU_SALEVAL_3 - DOUBLE
 ,CU_SALEVAL_4 = 0 -- CU_SALEVAL_4 - DOUBLE
 ,CU_SALEVAL_5 = 0 -- CU_SALEVAL_5 - DOUBLE
 ,CU_SALEVAL_6 = 0 -- CU_SALEVAL_6 - DOUBLE
 ,CU_SALEVAL_7 = 0 -- CU_SALEVAL_7 - DOUBLE
 ,CU_SALEVAL_8 = 0 -- CU_SALEVAL_8 - DOUBLE
 ,CU_SALEVAL_9 = 0 -- CU_SALEVAL_9 - DOUBLE
 ,CU_SALEVAL_10 = 0 -- CU_SALEVAL_10 - DOUBLE
 ,CU_COSTVAL_PTD = 0 -- CU_COSTVAL_PTD - DOUBLE
 ,CU_COSTVAL_YTD = 0 -- CU_COSTVAL_YTD - DOUBLE
 ,CU_SALEVAL_PTD = 0 -- CU_SALEVAL_PTD - DOUBLE
 ,CU_SALEVAL_YTD = 0 -- CU_SALEVAL_YTD - DOUBLE
 ,CU_COSTVALUE = 0 -- CU_COSTVALUE - DOUBLE
 ,CU_SALEVALUE = 0 -- CU_SALEVALUE - DOUBLE
 ,CU_SALEVAL_11 = 0 -- CU_SALEVAL_11 - DOUBLE
 ,CU_SALEVAL_12 = 0 -- CU_SALEVAL_12 - DOUBLE
 ,CU_SALEVAL_13 = 0 -- CU_SALEVAL_13 - DOUBLE
 ,CU_USERDATE1 = NOW() -- CU_USERDATE1 - DATETIME
 ,CU_USERDATE2 = NOW() -- CU_USERDATE2 - DATETIME
 ,CU_NOTES = '' -- CU_NOTES - TEXT
 ,CU_INV_ADD_CDE = 0 -- CU_INV_ADD_CDE - DOUBLE
 ,CU_DEL_ADD_CDE = 0 -- CU_DEL_ADD_CDE - DOUBLE
 ,CU_STAT_ADD_CDE = 0 -- CU_STAT_ADD_CDE - DOUBLE
 ,CU_DATE_INV = NOW() -- CU_DATE_INV - DATETIME
 ,CU_DATE_PAY = NOW() -- CU_DATE_PAY - DATETIME
 ,CU_USER_PUTIN = '' -- CU_USER_PUTIN - VARCHAR(4)
 ,CU_DATE_PUTIN = NOW() -- CU_DATE_PUTIN - DATETIME
 ,CU_DATE_EDITED = NOW() -- CU_DATE_EDITED - DATETIME
 ,CU_USER_EDITED = '' -- CU_USER_EDITED - VARCHAR(4)
 ,CU_MU_STATUS = '' -- CU_MU_STATUS - VARCHAR(1)
 ,CU_LINE_DISC = 0 -- CU_LINE_DISC - DOUBLE
 ,CU_TOT_DISC = 0 -- CU_TOT_DISC - DOUBLE
 ,CU_SETT_DISC_1 = 0 -- CU_SETT_DISC_1 - DOUBLE
 ,CU_SETT_DISC_2 = 0 -- CU_SETT_DISC_2 - DOUBLE
 ,CU_SETT_DAYS_1 = 0 -- CU_SETT_DAYS_1 - DOUBLE
 ,CU_SETT_DAYS_2 = 0 -- CU_SETT_DAYS_2 - DOUBLE
 ,CU_TERMS_OPTION = 0 -- CU_TERMS_OPTION - DOUBLE
 ,CU_CREDIT_LIMIT = 0 -- CU_CREDIT_LIMIT - DOUBLE
 ,CU_TERMS = '' -- CU_TERMS - VARCHAR(40)
 ,CU_DEL_CHARGE = 0 -- CU_DEL_CHARGE - DOUBLE
 ,CU_DEL_CHARGE_C = 0 -- CU_DEL_CHARGE_C - DOUBLE
 ,CU_DEL_CHG_PCNT = 0 -- CU_DEL_CHG_PCNT - DOUBLE
 ,CU_MIN_ORDR = 0 -- CU_MIN_ORDR - DOUBLE
 ,CU_MIN_ORDR_C = 0 -- CU_MIN_ORDR_C - DOUBLE
 ,CU_DUE_DAYS = 0 -- CU_DUE_DAYS - DOUBLE
 ,CU_A_P_DAYS = 0 -- CU_A_P_DAYS - DOUBLE
 ,CU_ANALYSIS = '' -- CU_ANALYSIS - VARCHAR(25)
 ,CU_TAX_CODE = '' -- CU_TAX_CODE - VARCHAR(4)
 ,CU_BANK_ANALYS = '' -- CU_BANK_ANALYS - VARCHAR(25)
 ,CU_PRIMARY = 0 -- CU_PRIMARY - DOUBLE NOT NULL
 ,CU_DEALERCODE = '' -- CU_DEALERCODE - VARCHAR(10)
 ,CU_ADDRESS_USER1 = '' -- CU_ADDRESS_USER1 - VARCHAR(30)
 ,CU_ADDRESS_USER2 = '' -- CU_ADDRESS_USER2 - VARCHAR(30)
 ,CU_EMAIL = '' -- CU_EMAIL - VARCHAR(64)
 ,CU_WEB_PASSWORD = '' -- CU_WEB_PASSWORD - VARCHAR(10)
 ,CU_SOURCE = '' -- CU_SOURCE - VARCHAR(1)
 ,CU_ACCOUNT_TYPE = '' -- CU_ACCOUNT_TYPE - VARCHAR(1)
 ,CU_DOC_DESTINATION = '' -- CU_DOC_DESTINATION - VARCHAR(10)
 ,CU_COUNTRY = '' -- CU_COUNTRY - VARCHAR(35)
 ,CU_DO_NOT_USE = 0 -- CU_DO_NOT_USE - TINYINT(4) NOT NULL
 ,CU_CREDIT_CONTROLLER = '' -- CU_CREDIT_CONTROLLER - VARCHAR(4)
 ,CU_TERMS_LINK = 0 -- CU_TERMS_LINK - INT(11)
 ,CU_CURR_CREDIT_LIMIT = 0 -- CU_CURR_CREDIT_LIMIT - DOUBLE
 ,CU_PAYMENT_PROMISED = 0 -- CU_PAYMENT_PROMISED - DOUBLE
 ,CU_PAYMENT_PROMISED_DATE = NOW() -- CU_PAYMENT_PROMISED_DATE - DATETIME
 ,CU_CUSTOM_TERMS_TEMPLATE = 0 -- CU_CUSTOM_TERMS_TEMPLATE - TINYINT(4) NOT NULL
 ,CU_PAYMENT_PROMISED_CURRENCY = '' -- CU_PAYMENT_PROMISED_CURRENCY - VARCHAR(4)
 ,CU_COMPANY_REG_NUMBER = '' -- CU_COMPANY_REG_NUMBER - VARCHAR(20)
 ,CU_DIRECT_DEBIT_TYPE = '' -- CU_DIRECT_DEBIT_TYPE - VARCHAR(1) NOT NULL
 ,CU_INV_LAYOUT_LINK = 0 -- CU_INV_LAYOUT_LINK - INT(11)
 ,CU_CRN_LAYOUT_LINK = 0 -- CU_CRN_LAYOUT_LINK - INT(11)
 ,CU_COMMITTED_ORDER_TOTAL = 0 -- CU_COMMITTED_ORDER_TOTAL - DOUBLE NOT NULL
 ,CU_COMMITTED_ORDER_TOTAL_C = 0 -- CU_COMMITTED_ORDER_TOTAL_C - DOUBLE NOT NULL
 ,CU_BIC_CODE = '' -- CU_BIC_CODE - VARCHAR(11)
 ,CU_AUDDIS_DATE = NOW() -- CU_AUDDIS_DATE - DATETIME
 ,CU_DIRECT_DEBIT_STATUS = '' -- CU_DIRECT_DEBIT_STATUS - VARCHAR(2) NOT NULL
 ,CU_BUYING_GROUP_FLAG = 0 -- CU_BUYING_GROUP_FLAG - TINYINT(4) NOT NULL
 ,CU_DIRECT_DEBIT_MANDATE_ID = '' -- CU_DIRECT_DEBIT_MANDATE_ID - VARCHAR(35)
 ,CU_DIRECT_DEBIT_SIGNATURE_DATE = NOW() -- CU_DIRECT_DEBIT_SIGNATURE_DATE - DATETIME
 ,CU_DD_COLLECTION_ELAPSED_DAYS = 0 -- CU_DD_COLLECTION_ELAPSED_DAYS - TINYINT(4) NOT NULL
 ,CU_DO_NOT_EMAIL_FROM_ACLOUD = 0 -- CU_DO_NOT_EMAIL_FROM_ACLOUD - TINYINT(4) NOT NULL
WHERE
<Search Conditions,,>