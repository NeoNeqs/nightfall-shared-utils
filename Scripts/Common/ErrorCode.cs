using Godot;

namespace SharedUtils.Common
{
    public struct ErrorCode
    {
        private int InternalValue { get; set; }

        public const int Ok = (int)Error.Ok;
        public const int Failed = (int)Error.Failed;
        public const int Unavailable = (int)Error.Unavailable;
        public const int Unconfigured = (int)Error.Unconfigured;
        public const int Unauthorized = (int)Error.Unauthorized;
        public const int ParameterRangeError = (int)Error.ParameterRangeError;
        public const int OutOfMemory = (int)Error.OutOfMemory;
        public const int FileNotFound = (int)Error.FileNotFound;
        public const int FileBadDrive = (int)Error.FileBadDrive;
        public const int FileBadPath = (int)Error.FileBadPath;
        public const int FileNoPermission = (int)Error.FileNoPermission;
        public const int FileAlreadyInUse = (int)Error.FileAlreadyInUse;
        public const int FileCantOpen = (int)Error.FileCantOpen;
        public const int FileCantWrite = (int)Error.FileCantWrite;
        public const int FileCantRead = (int)Error.FileCantRead;
        public const int FileUnrecognized = (int)Error.FileUnrecognized;
        public const int FileCorrupt = (int)Error.FileCorrupt;
        public const int FileMissingDependencies = (int)Error.FileMissingDependencies;
        public const int FileEof = (int)Error.FileEof;
        public const int CantOpen = (int)Error.CantOpen;
        public const int CantCreate = (int)Error.CantCreate;
        public const int QueryFailed = (int)Error.QueryFailed;
        public const int AlreadyInUse = (int)Error.AlreadyInUse;
        public const int Locked = (int)Error.Locked;
        public const int Timeout = (int)Error.Timeout;
        public const int CantConnect = (int)Error.CantConnect;
        public const int CantResolve = (int)Error.CantResolve;
        public const int ConnectionError = (int)Error.ConnectionError;
        public const int CantAcquireResource = (int)Error.CantAcquireResource;
        public const int CantFork = (int)Error.CantFork;
        public const int InvalidData = (int)Error.InvalidData;
        public const int InvalidParameter = (int)Error.InvalidParameter;
        public const int AlreadyExists = (int)Error.AlreadyExists;
        public const int DoesNotExist = (int)Error.DoesNotExist;
        public const int DatabaseCantRead = (int)Error.DatabaseCantRead;
        public const int DatabaseCantWrite = (int)Error.DatabaseCantWrite;
        public const int CompilationFailed = (int)Error.CompilationFailed;
        public const int MethodNotFound = (int)Error.MethodNotFound;
        public const int LinkFailed = (int)Error.LinkFailed;
        public const int ScriptFailed = (int)Error.ScriptFailed;
        public const int CyclicLink = (int)Error.CyclicLink;
        public const int InvalidDeclaration = (int)Error.InvalidDeclaration;
        public const int DuplicateSymbol = (int)Error.DuplicateSymbol;
        public const int ParseError = (int)Error.ParseError;
        public const int Busy = (int)Error.Busy;
        public const int Skip = (int)Error.Skip;
        public const int Help = (int)Error.Help;
        public const int Bug = (int)Error.Bug;
        public const int PrinterOnFire = (int)Error.PrinterOnFire;
        public const int CantSave = 49;
        public const int EnvironmentVariableNotSet = 50;
        public const int DirBadPath = 51;
        public const int DataTooLong = 52;
        public const int MissingAttribute = 53;
        public const int NotValid = 54;


        public static implicit operator ErrorCode(int value)
        {
            return new ErrorCode
            {
                InternalValue = value
            };
        }

        public static implicit operator int(ErrorCode errorCode)
        {
            return errorCode.InternalValue;
        }

        public static implicit operator bool(ErrorCode errorCode)
        {
            return errorCode == Ok;
        }

        public static bool operator !(ErrorCode errorCode)
        {
            return errorCode != Ok;
        }

        public override string ToString()
        {
            return InternalValue switch
            {
                Ok => nameof(Ok),
                Failed => nameof(Failed),
                Unavailable => nameof(Unavailable),
                Unconfigured => nameof(Unconfigured),
                Unauthorized => nameof(Unauthorized),
                ParameterRangeError => nameof(ParameterRangeError),
                OutOfMemory => nameof(OutOfMemory),
                FileNotFound => nameof(FileNotFound),
                FileBadDrive => nameof(FileBadDrive),
                FileBadPath => nameof(FileBadPath),
                FileNoPermission => nameof(FileNoPermission),
                FileAlreadyInUse => nameof(FileAlreadyInUse),
                FileCantOpen => nameof(FileCantOpen),
                FileCantWrite => nameof(FileCantWrite),
                FileCantRead => nameof(FileCantRead),
                FileUnrecognized => nameof(FileUnrecognized),
                FileCorrupt => nameof(FileCorrupt),
                FileMissingDependencies => nameof(FileMissingDependencies),
                FileEof => nameof(FileEof),
                CantOpen => nameof(CantOpen),
                CantCreate => nameof(CantCreate),
                QueryFailed => nameof(QueryFailed),
                AlreadyInUse => nameof(AlreadyInUse),
                Locked => nameof(Locked),
                Timeout => nameof(Timeout),
                CantConnect => nameof(CantConnect),
                CantResolve => nameof(CantResolve),
                ConnectionError => nameof(ConnectionError),
                CantAcquireResource => nameof(CantAcquireResource),
                CantFork => nameof(CantFork),
                InvalidData => nameof(InvalidData),
                InvalidParameter => nameof(InvalidParameter),
                AlreadyExists => nameof(AlreadyExists),
                DoesNotExist => nameof(DoesNotExist),
                DatabaseCantRead => nameof(DatabaseCantRead),
                DatabaseCantWrite => nameof(DatabaseCantWrite),
                CompilationFailed => nameof(CompilationFailed),
                MethodNotFound => nameof(MethodNotFound),
                LinkFailed => nameof(LinkFailed),
                ScriptFailed => nameof(ScriptFailed),
                CyclicLink => nameof(CyclicLink),
                InvalidDeclaration => nameof(InvalidDeclaration),
                DuplicateSymbol => nameof(DuplicateSymbol),
                ParseError => nameof(ParseError),
                Busy => nameof(Busy),
                Skip => nameof(Skip),
                Help => nameof(Help),
                Bug => nameof(Bug),
                PrinterOnFire => nameof(PrinterOnFire),
                CantSave => nameof(CantSave),
                EnvironmentVariableNotSet => nameof(EnvironmentVariableNotSet),
                DirBadPath => nameof(DirBadPath),
                DataTooLong => nameof(DataTooLong),
                MissingAttribute => nameof(MissingAttribute),
                NotValid => nameof(NotValid),
                _ => string.Empty,
            };
        }
    }
}
