using Godot;
using System.Diagnostics.CodeAnalysis;
using Value = System.Int64;

namespace Nightfall.SharedUtils.InfoCodes
{
    [SuppressMessage("ReSharper", "BuiltInTypeReferenceStyle")]
    public struct NFError
    {
        private Value InternalValue { set; get; }

        public const Value Ok = (Value) Error.Ok;
        public const Value Failed = (Value) Error.Failed;
        public const Value Unavailable = (Value) Error.Unavailable;
        public const Value Unconfigured = (Value) Error.Unconfigured;
        public const Value Unauthorized = (Value) Error.Unauthorized;
        public const Value ParameterRangeError = (Value) Error.ParameterRangeError;
        public const Value OutOfMemory = (Value) Error.OutOfMemory;
        public const Value FileNotFound = (Value) Error.FileNotFound;
        public const Value FileBadDrive = (Value) Error.FileBadDrive;
        public const Value FileBadPath = (Value) Error.FileBadPath;
        public const Value FileNoPermission = (Value) Error.FileNoPermission;
        public const Value FileAlreadyInUse = (Value) Error.FileAlreadyInUse;
        public const Value FileCantOpen = (Value) Error.FileCantOpen;
        public const Value FileCantWrite = (Value) Error.FileCantWrite;
        public const Value FileCantRead = (Value) Error.FileCantRead;
        public const Value FileUnrecognized = (Value) Error.FileUnrecognized;
        public const Value FileCorrupt = (Value) Error.FileCorrupt;
        public const Value FileMissingDependencies = (Value) Error.FileMissingDependencies;
        public const Value FileEof = (Value) Error.FileEof;
        public const Value CantOpen = (Value) Error.CantOpen;
        public const Value CantCreate = (Value) Error.CantCreate;
        public const Value QueryFailed = (Value) Error.QueryFailed;
        public const Value AlreadyInUse = (Value) Error.AlreadyInUse;
        public const Value Locked = (Value) Error.Locked;
        public const Value Timeout = (Value) Error.Timeout;
        public const Value CantConnect = (Value) Error.CantConnect;
        public const Value CantResolve = (Value) Error.CantResolve;
        public const Value ConnectionError = (Value) Error.ConnectionError;
        public const Value CantAcquireResource = (Value) Error.CantAcquireResource;
        public const Value CantFork = (Value) Error.CantFork;
        public const Value InvalidData = (Value) Error.InvalidData;
        public const Value InvalidParameter = (Value) Error.InvalidParameter;
        public const Value AlreadyExists = (Value) Error.AlreadyExists;
        public const Value DoesNotExist = (Value) Error.DoesNotExist;
        public const Value DatabaseCantRead = (Value) Error.DatabaseCantRead;
        public const Value DatabaseCantWrite = (Value) Error.DatabaseCantWrite;
        public const Value CompilationFailed = (Value) Error.CompilationFailed;
        public const Value MethodNotFound = (Value) Error.MethodNotFound;
        public const Value LinkFailed = (Value) Error.LinkFailed;
        public const Value ScriptFailed = (Value) Error.ScriptFailed;
        public const Value CyclicLink = (Value) Error.CyclicLink;
        public const Value InvalidDeclaration = (Value) Error.InvalidDeclaration;
        public const Value DuplicateSymbol = (Value) Error.DuplicateSymbol;
        public const Value ParseError = (Value) Error.ParseError;
        public const Value Busy = (Value) Error.Busy;
        public const Value Skip = (Value) Error.Skip;
        public const Value Help = (Value) Error.Help;
        public const Value Bug = (Value) Error.Bug;
        public const Value PrinterOnFire = (Value) Error.PrinterOnFire;
        public const Value MessageEmpty = 49;
        public const Value InvalidUnicodeCodePoint = 50;
        public const Value NotEnoughData = 51;
        public const Value NoDataSupplied = 52;
        public const Value PeerNotFound = 53;
        public const Value UnsuccessfulRemoval = 54;
        public const Value PacketTypeCodeTooShort = 55;
        public const Value YAMLError = 61;

        public static implicit operator NFError(Value value)
        {
            return new NFError
            {
                InternalValue = value
            };
        }

        public static implicit operator NFError(Error error)
        {
            return new NFError
            {
                InternalValue = (Value) error
            };
        }

        public static implicit operator Value(NFError level)
        {
            return level.InternalValue;
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
                MessageEmpty => nameof(MessageEmpty),
                InvalidUnicodeCodePoint => nameof(InvalidUnicodeCodePoint),
                NotEnoughData => nameof(NotEnoughData),
                NoDataSupplied => nameof(NoDataSupplied),
                PeerNotFound => nameof(PeerNotFound),
                UnsuccessfulRemoval => nameof(UnsuccessfulRemoval),
                PacketTypeCodeTooShort => nameof(PacketTypeCodeTooShort),
                YAMLError => nameof(YAMLError),
                _ => string.Empty,
            };
        }
    }
}