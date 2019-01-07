using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SingletonHelper {
	private static GameObject host;
	public static T makeSingleton<T>() where T : UnityEngine.Component {
		if(!host)
			host = new GameObject("__singletonHost__");

		return host.AddComponent<T>();
	}
}
