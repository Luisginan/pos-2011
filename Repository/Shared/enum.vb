Public Enum CRUD
    ON_SAVE = 1
    ON_UPDATE = 2
    ON_DELETE = 3
    ON_HARD_DELETE = 4
End Enum
Public Enum USER_LEVEL
    SUPERVISOR = 1
    USER_ENTRY = 2
End Enum
Public Enum TRANSACTION_MODE
    INSERT_ITEM = 0
    CHANGE_QTY = 1
    CHANGE_PRICE = 2
End Enum
Public Enum CASHIER_MODE
    ON_DEFAULT = 1
    ON_CANCELATION = 2
    ON_SUSPEND = 3
End Enum
Public Enum DB_MODE
    ON_RESTORE = 1
    ON_DOWNLOAD_BACKUP = 2
End Enum
Public Enum BARCODE_MODE
    ON_NORMAL = 0
    ON_AUTOENTER = 1
End Enum