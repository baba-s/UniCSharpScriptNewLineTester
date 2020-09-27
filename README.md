# UniCSharpScriptNewLineTester

C# スクリプトの改行コードに Win と Unix が混在していないかのテスト

## 概要

```
There are inconsistent line endings in the 'XXXX.cs' script. 
Some are Mac OS X (UNIX) and some are Windows.
This might lead to incorrect line numbers in stacktraces and compiler errors. 
Many text editors can fix this using Convert Line Endings menu commands.
```

C# スクリプトの改行コードに Win と Unix が混在していると  
Unity の Console に上記の警告ログが出力されますが  
Unity プロジェクトにこの警告が出力される C# スクリプトが存在しないかテストします  
