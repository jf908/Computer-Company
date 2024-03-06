using System;
using System.Collections.Generic;
using MoonSharp.Interpreter;

// console.commands['foo']                     -- Get console command (for builtins, a function which executes them)
// console.commands['foo'] = function(...) end -- Add terminal commands. Errors if you try to overwrite a builtin function. One argument per space-separated terminal input

[MoonSharpUserData]
public class CCCommands {
    private Dictionary<string, Func<ScriptExecutionContext, CallbackArguments, DynValue>> insertions = new Dictionary<string, Func<ScriptExecutionContext, CallbackArguments, DynValue>>();

    private static HashSet<string> defaults = new HashSet<string>(); // TODO: populate this??

	public Func<ScriptExecutionContext, CallbackArguments, DynValue> this[string name]
	{
		get {
            if (defaults.Contains(name)) {
                throw new Exception("get the default thingy");
            }
            return insertions[name];
        }
		set {
            if (defaults.Contains(name)) {
                throw new Exception("can't overwrite defaults");
            }
            insertions[name] = value;
        }
	}
}