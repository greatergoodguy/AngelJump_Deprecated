using UnityEngine;
using System.Collections;


public class JuStMock : JuSt_Base {
	
	private static JuStMock instance;
	private JuStMock() {}
	public static JuStMock Instance {
		get 
		{
			if (instance == null) {
				instance = new JuStMock();}
			
			return instance;
		}
	}
}

