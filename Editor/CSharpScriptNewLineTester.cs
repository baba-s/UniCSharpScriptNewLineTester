using NUnit.Framework;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;

namespace Kogane.Internal
{
	internal sealed class CSharpScriptNewLineTester
	{
		private static readonly Regex WIN_REGEX  = new Regex( @"\r\n", RegexOptions.Singleline );
		private static readonly Regex UNIX_REGEX = new Regex( @"[^\r]\n", RegexOptions.Singleline );

		[Test]
		public void Test()
		{
			bool IsCheck( string path )
			{
				var lines  = File.ReadAllText( path );
				var isWin  = WIN_REGEX.IsMatch( lines );
				var isUnix = UNIX_REGEX.IsMatch( lines );

				return isWin && isUnix;
			}

			var scriptPathList = AssetDatabase
					.FindAssets( "t:Script" )
					.Select( x => AssetDatabase.GUIDToAssetPath( x ) )
					.Where( x => x.StartsWith( "Assets/" ) )
					.Where( x => IsCheck( x ) )
					.ToArray()
				;

			if ( scriptPathList.Length <= 0 ) return;

			var builder = new StringBuilder();

			foreach ( var scriptPath in scriptPathList )
			{
				builder.AppendLine( scriptPath );
			}

			Assert.Fail( builder.ToString() );
		}
	}
}