using UnityEngine;
using System.Collections;

public class SeTiMock : SeTi_Base {

	private static SeTiMock instance;
	private SeTiMock() {}
	public static SeTiMock Instance {
		get 
		{
			if (instance == null) {
				instance = new SeTiMock();}

			return instance;
		}
	}
}
