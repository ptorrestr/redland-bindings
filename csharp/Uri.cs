//
// Uri.cs: Redland Uri class.
//
// Author:
//	Cesar Lopez Nataren (cesar@ciencias.unam.mx)
//
// (C) 2004, Cesar Lopez Nataren
//

using System;
using System.Runtime.InteropServices;

namespace Rdf {

	public class Uri : IWrapper {

		IntPtr uri;

		public IntPtr Handle {
			get { return uri; }
		}

		[DllImport ("librdf")]
		static extern IntPtr librdf_new_uri (IntPtr world, string uri_str);

		private Uri (World world, string uri_str)
		{
			uri = librdf_new_uri (world.Handle, uri_str);
			Console.WriteLine ("Making URI from string {0} giving handle {1}", uri_str, uri);
		}

		public Uri (string uri)
			: this (Redland.World, uri)
		{
		}

		[DllImport ("librdf")]
		static extern string librdf_uri_to_string (IntPtr uri);

		public override string ToString ()
		{
			return librdf_uri_to_string (uri);
		}
	}
}
