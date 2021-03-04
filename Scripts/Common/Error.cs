using System;
using Godot;

namespace SharedUtils.Scripts.Common
{
    public enum ErrorCode
    {
        Ok = 0,
        Failed = 1,
        Unavailable = 2,
        Unconfigured = 3,
        Unauthorized = 4,
        ParameterRangeError = 5,
        OutOfMemory = 6,
        FileNotFound = 7,
        FileBadDrive = 8,
        FileBadPath = 9,
        FileNoPermission = 10,
        FileAlreadyInUse = 11,
        FileCantOpen = 12,
        FileCantWrite = 13,
        FileCantRead = 14,
        FileUnrecognized = 15,
        FileCorrupt = 16,
        FileMissingDependencies = 17,
        FileEof = 18,
        CantOpen = 19,
        CantCreate = 20,
        QueryFailed = 21,
        AlreadyInUse = 22,
        Locked = 23,
        Timeout = 24,
        CantConnect = 25,
        CantResolve = 26,
        ConnectionError = 27,
        CantAcquireResource = 28,
        CantFork = 29,
        InvalidData = 30,
        InvalidParameter = 31,
        AlreadyExists = 32,
        DoesNotExist = 33,
        DatabaseCantRead = 34,
        DatabaseCantWrite = 35,
        CompilationFailed = 36,
        MethodNotFound = 37,
        LinkFailed = 38,
        ScriptFailed = 39,
        CyclicLink = 40,
        InvalidDeclaration = 41,
        DuplicateSymbol = 42,
        ParseError = 43,
        Busy = 44,
        Skip = 45,
        Help = 46,
        Bug = 47,
        PrinterOnFire = 48,
        CantSave = 49,
        EnvironmentVariableNotSet = 50,
        DirBadPath = 51,
    }
}