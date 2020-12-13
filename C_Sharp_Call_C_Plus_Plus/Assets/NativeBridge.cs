using System.Runtime.InteropServices;
using System;
using AOT;

[StructLayout(LayoutKind.Sequential)]
public struct People {

	public int age;
	
	public IntPtr name;
}

[StructLayout(LayoutKind.Sequential)]
public struct PeopleList {
	public People people1;

	public People people2;
}

[StructLayout(LayoutKind.Sequential)]
public struct Peoples {
	public int count;

	public IntPtr peopleListPtr;
}

public delegate void On_C_Plus_Plus_Callback(int a, bool b, string c);

public class NativeBridge {

	public const string libName = "c_sharp_to_c_plus";

	[DllImport(libName, CharSet = CharSet.Ansi)]
	public static extern int startLogService();

	[DllImport(libName, CharSet = CharSet.Ansi)]
	public static extern int getSumValue(int value1, int value2);

	[DllImport(libName, CharSet = CharSet.Ansi)]
	public static extern int setPeople(People people);

	[DllImport(libName, CharSet = CharSet.Ansi)]
	public static extern int modifyPeople(ref People people);

	[DllImport(libName, CharSet = CharSet.Ansi)]
	public static extern int setPeoples(Peoples peoples);

	[DllImport(libName, CharSet = CharSet.Ansi)]
	public static extern int getPeoples(ref Peoples peoples);

	[DllImport(libName, CharSet = CharSet.Ansi)]
	public static extern int setPeopleList(PeopleList peopleList);

	[DllImport(libName, CharSet = CharSet.Ansi)]
	public static extern int modifyPeopleList(ref PeopleList peopleList);

	[DllImport(libName, CharSet = CharSet.Ansi)]
	public static extern void testCallback();

	[DllImport(libName, CharSet = CharSet.Ansi)]
	public static extern void initCallback(On_C_Plus_Plus_Callback callback, On_C_Plus_Plus_Callback callback2);
}
