using System.Runtime.InteropServices;
using UnityEngine;
using AOT;

public class HelloUnity : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
		People people = new People();
		people.age = 50;
		people.name = Marshal.StringToHGlobalAnsi("Bobo");

		int ret1 = NativeBridge.startLogService();
		Debug.LogFormat("startLogService ret1 = {0} ", ret1);

		int ret2 = NativeBridge.getSumValue(100, 200);
		Debug.LogFormat("startLogService ret2 = {0} ", ret2);

		int ret3 = NativeBridge.setPeople(people);
		Debug.LogFormat("setPeople ret3 = {0} ", ret3);

		int ret4 = NativeBridge.modifyPeople(ref people);
		Debug.LogFormat("modifyPeople ret4 = {0},  age = {1}  ,name = {2} ", ret4, people.age, Marshal.PtrToStringAnsi(people.name));

		People p1 = new People();
		p1.age = 50;
		p1.name = Marshal.StringToHGlobalAnsi("bobo");

		People p2 = new People();
		p2.age = 100;
		p2.name = Marshal.StringToHGlobalAnsi("bobo2");

		PeopleList peopleList = new PeopleList();
		peopleList.people1 = p1;
		peopleList.people2 = p2;

		int ret5 = NativeBridge.setPeopleList(peopleList);
		Debug.LogFormat("setPeopleList ret5 = {0} ", ret5);

		int ret6 = NativeBridge.modifyPeopleList(ref peopleList);
		Debug.LogFormat("setPeopleList ret6 = {0} ", ret6);

		NativeBridge.initCallback(On_C_Plus_Plue_Callback_1, On_C_Plus_Plue_Callback_2);

		NativeBridge.testCallback();
    }

	[MonoPInvokeCallback(typeof(On_C_Plus_Plus_Callback))]
	public static void On_C_Plus_Plue_Callback_1(int a, bool b, string c) {
		Debug.LogFormat("On_C_Plus_Plue_Callback1 a: {0}, b: {1}, c: {2}", a, b, c);
	}

	[MonoPInvokeCallback(typeof(On_C_Plus_Plus_Callback))]
	public static void On_C_Plus_Plue_Callback_2(int a, bool b, string c)
	{
		Debug.LogFormat("On_C_Plus_Plue_Callback1 a: {0}, b: {1}, c: {2}", a, b, c);
	}
}
