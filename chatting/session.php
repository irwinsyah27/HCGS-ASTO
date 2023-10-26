<?php
class SessionManager
{
	var $life_time;

	function SessionManager()
	{
		//baca setting maxlifetime dari PHP
		$this->life_time = get_cfg_var("session.gc_maxlifetime");

		//registrasikan fungsi yang akan dipanggil pada saat
		//terjadi proses baca tulis session
		session_set_save_handler(
		array(&$this, "open"),
		array(&$this, "close"),
		array(&$this, "read"),
		array(&$this, "write"),
		array(&$this, "destroy"),
		array(&$this, "gc")
		);
	}
	 
	function open($save_path, $session_name)
	{
		global $sess_save_path;
		$sess_save_path = $save_path;
		return true;
	}

	function close()
	{
		return true;
	}

	function read($id)
	{
		$data = '';
		$time = time();
		$newid = mysql_real_escape_string($id);
		$sql = "SELECT data FROM sessions WHERE session_id = '" . $newid . "' AND expires > " . $time;
		$rs = mysql_query($sql);
		$a = mysql_num_rows($rs);
		if ($a > 0)
		{
			$row = mysql_fetch_array($rs);
			$data = $row['data'];
		}
		return $data;
	}

	function write($id, $data)
	{
		$time = time() + $this->life_time;
		$newid = mysql_real_escape_string($id);
		$newdata = mysql_real_escape_string($data);
		$sql = "REPLACE sessions (session_id, data, expires)
           VALUES ('" . $newid . "','" . $newdata . "'," . $time . ")";
		$rs = mysql_query($sql);
		return true;
	}

	function destroy($id)
	{
		$newid = mysql_real_escape_string($id);
		$sql = "DELETE FROM sessions
           WHERE session_id = '" . $newid . "'";
		mysql_query($sql);
		return true;
	}

	function gc()
	{
		$sql = "DELETE FROM sessions
           WHERE expires < UNIX_TIMESTAMP();";
		mysql_query($sql);
		return true;
	}
}
?>