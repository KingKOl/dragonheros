using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Mono.Data.Sqlite;
using ns_predefine;
using System;

public class dbpreheader{
	private string _dbpath; 
	private string _constr;
	private SqliteConnection _sqlcon;
	private SqliteCommand _sqlcmd;
	private SqliteDataReader _sqlreader;

	public SqliteDataReader SQLReader{get{ return _sqlreader;}}

	public dbpreheader(){
		_sqlcon = null;
		_sqlcmd = null;
		_sqlreader = null;
	}

	public void initdb(string name , bool rewrite = true){
		releasedb ();

		try{
			if (Application.platform == RuntimePlatform.Android) {
				_dbpath = string.Format("{0}/{1}",Application.persistentDataPath,name); 
				_constr = string.Format ("URI=file:{0}",_dbpath);

				if(rewrite){
					if (File.Exists (_dbpath)) {  
						//数据库已经存在,删掉
						File.Delete(_dbpath);
					} 
					//把StreamingAssets的文件拷贝过去
					WWW loadDB = new WWW (string.Format ("jar:file://{0}!/assets/{1}", Application.dataPath, name));  
					while (!loadDB.isDone) {
						System.Threading.Thread.Sleep (100);
					}  
					File.WriteAllBytes (_dbpath, loadDB.bytes); 
				}else{
					if (!File.Exists (_dbpath)) {  
						//如果数据库文件没有被创建，则创建数据库文件  
						WWW loadDB = new WWW (string.Format ("jar:file://{0}!/assets/{1}", Application.dataPath, name));  
						while (!loadDB.isDone) {
							System.Threading.Thread.Sleep (100);
						}  
						File.WriteAllBytes (_dbpath, loadDB.bytes); 
					}
				}
			} else if (Application.platform == RuntimePlatform.WindowsEditor) {
				_dbpath = string.Format("{0}/StreamingAssets/{1}",Application.dataPath,name); 
				_constr = string.Format ("Data Source={0}",_dbpath);
			}
			_sqlcon = new SqliteConnection ( _constr );  
			_sqlcon.Open();
		}catch(Exception e){
			Debug.Log(e.ToString());
		}
	}

	public void releasedb(){
		if (_sqlcon != null) {
			_sqlcon.Close ();
			_sqlcon = null;
		}
		if (_sqlcmd != null) {
			_sqlcmd.Dispose ();
			_sqlcmd = null;
		}
		if (_sqlreader != null) {
			_sqlreader.Close ();
			_sqlreader = null;
		}
	}

	public void executequery(string _querycmd){
		_sqlcmd = _sqlcon.CreateCommand ();
		_sqlcmd.CommandText = _querycmd;
		_sqlreader = _sqlcmd.ExecuteReader ();
		_sqlcmd.Dispose ();
		_sqlcmd = null;
	}
}
