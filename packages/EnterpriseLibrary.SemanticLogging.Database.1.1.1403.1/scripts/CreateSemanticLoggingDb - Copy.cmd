sqlcmd -S pfernandes01\sqldev01 -E -i CreateSemanticLoggingDatabase.sql
sqlcmd -S pfernandes01\sqldev01 -E -i CreateSemanticLoggingDatabaseObjects.sql -d Logging