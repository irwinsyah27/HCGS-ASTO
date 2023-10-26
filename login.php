<?php

class ldap{
    private $ldap;
    private $ldapUseSecure;
    private $ldapHost;
    private $ldapPort;
    private $ldapPortSecure;
    private $ldapUser;
    private $ldapPass;
    private $ldapResource;
    private $ldapResultset;
    private $ldapWindows;
    private $ldapDomain;
    // Class constructor
    function __construct(){
        $this->ldapUseSecure = true;
        $this->ldapWindows = true;
        $this->ldapPort = 389;
        $this->ldapPortSecure = 636;
        $this->ldapResource = null;
        $this->ldapResultset = null;
    }
    // Class Destructor
    function __destruct(){
        unset($this->ldap);
        unset($this->ldapUseSecure);
        unset($this->ldapHost);
        unset($this->ldapPort);
        unset($this->ldapPortSecure);
        unset($this->ldapUser);
        unset($this->ldapPass);
        unset($this->ldapResource);
        unset($this->ldapResultset);
        unset($this->ldapWindows);
        unset($this->ldapDomain);
    }
    // Set Ldap Host
    function s_Host($host){
        if(!empty($host)){$this->ldapHost = $host;}
    }
    // Set LdapPort
    function s_Port($port){
        if(!empty($port)){$this->ldapPort = $port;}
    }
    function s_PortSecure($port){
        if(!empty($port)){$this->ldapPortSecure = $port;}
    }
    // Set LdapUser
    function s_User($user){
        if(!empty($user)){
            $this->ldapUser = $user;
        }else{
            return false;
        }
    }
    // Set LdapPasswd
    function s_Pass($pass){
        if(!empty($pass)){
            $this->ldapPass = $pass;
        }else{
            return false;
        }
    }
   
    function s_Windows($win){
        if($win == true || $win == false){$this->ldapWindows = $win;}
    }
   
    function s_Ldapsecure($secure){
        if($secure == true || $secure == false){ $this->ldapUseSecure = $secure; }
    }
   
    function s_Domain($domain){
        if(!empty($domain)){$this->ldapDomain = $domain;}
    }
   
    function g_Host(){
        return $this->ldapHost;
    }
   
    function g_Port(){
        return $this->ldapPort;
    }
   
    function g_PortSecure(){
        return $this->ldapPortSecure;
    }
   
    function g_User(){
        if(!empty($this->ldapUser)){
            return $this->ldapUser;
        }else{
            return false;
        }
    }
   
    function g_Pass(){
        if(!empty($this->ldapPass)){
            return true;
        }else{
            return false;
        }
    }
   
    function g_Windows(){
        return $this->ldapWindows;
    }
   
    function g_Domain(){
        return $this->ldapDomain;
    }
   
    function LdapConn(){
        if($this->ldapUseSecure){
            if($this->ldapResource  = ldap_connect($this->ldapHost, $this->ldapPortSecure)){
                if($this->ldapWindows == true){
                    ldap_set_option($this->ldapResource, LDAP_OPT_PROTOCOL_VERSION, 3);
                    ldap_set_option($this->ldapResource, LDAP_OPT_REFERRALS, 0);
                }
                return true;
            }
        }else{
            if($this->ldapResource  = ldap_connect($this->ldapHost, $this->ldapPort)){
                if($this->ldapWindows == true){
                    ldap_set_option($this->ldapResource, LDAP_OPT_PROTOCOL_VERSION, 3);
                    ldap_set_option($this->ldapResource, LDAP_OPT_REFERRALS, 0);
                }
                return true;
            }
        }
        return false;
    }
   
    function LdapBind(){
        if(!empty($this->ldapUser) && !empty($this->ldapPass)){
            if($this->ldapResultset = @ldap_bind($this->ldapResource, $this->GetldapUPN(), $this->ldapPass)){
                return true;
            }else{
                return false;
            }
        }else{
            if($this->ldapResultset = ldap_bind($this->ldapResource)){
                return true;
            }else{
                return false;
            }
        }
    }
   
    function GetldapUPN(){
        if(!empty($this->ldapDomain) && !empty($this->ldapUser)){
            if(!empty($this->ldapUser)){
                return $this->ldapUser."@".$this->ldapDomain;
            }
        }
        return false;
    }
   
    function GetldapDomain(){
        if(!empty($this->ldapDomain)){
            $DC = explode(".", $this->ldapDomain);
            return "DC=$DC[0],DC=$DC[1]";
        }
        return false;
    }
   
    public function getAttribute($attr){
        /* The relevant object we are looking for to limit the scope */
        $filter = 'samaccountname='.$this->ldapUser;
        /* We want to filter on one object so we dont get "All" information back.... Its Ldap Hell!*/
        $rObjs = array($attr);
        /* Execute the actual search on the directory */
        if($this->ldapResultset = @ldap_search($this->ldapResource, $this->GetldapDomain(), $filter, $rObjs)){
            $info = ldap_get_entries($this->ldapResource, $this->ldapResultset);
        }
        /* Validate we have a result that matters */
        if($info['count'] > 0){
            if(@$info[0][$attr]['count'] > 0){
                return $info[0][$attr][0];
            }else{
                return false;
            }
        }else{
            return false;
        }   
    }
   
    public function getMemberships(){
        /* The relevant object we are looking for to limit the scope */
        $filter = 'samaccountname='.$this->ldapUser;
        /* We want to filter on one object so we dont get "All" information back.... Its Ldap Hell!*/
        $rObjs = array('memberof');
        /* Execute the actual search on the directory */
        if($this->ldapResultset = @ldap_search($this->ldapResource, $this->GetldapDomain(), $filter, $rObjs)){
            $info = ldap_get_entries($this->ldapResource, $this->ldapResultset);
        }
        /* Validate we have a result that matters */
        if($info['count'] > 0){
            foreach($info[0]['memberof'] as $key => $value){
                $memberships[$key]=$value;
            }
            if(is_array($memberships)){
                return $memberships;
            }else{
                return false;
            }
        }else{
            return false;
        }   
    }
}
 
 
?> 

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Login Page - pidedesign.net</title>

<link href="Tools/style.css" rel="stylesheet" type="text/css" />

<!--[if IE 6]><link rel="stylesheet" type="text/css" href="Tools/ie6.css" media="screen"><![endif]-->
<!--[if IE 7]><link rel="stylesheet" type="text/css" href="Tools/ie7.css" media="screen"><![endif]-->

</head>

<body>

<div id="login"><!-- design by www.pidedesign.net -->

<div id="title">
<p>Index KPP MINING </p>
<p><span class="color_site">[ Site Rantau]</span></p>
<!-- titolo sito -->
</div>

<form method="POST" action="<?php echo $_SERVER['PHP_SELF']; ?>" name="SSOLOGIN">

<!-- username -->
<div class="item">UserID</div>
<div class="input"><input name="username" type="text" /></div>

<!-- password -->
<div class="item">Password</div>
<div class="input"><input name="password" type="password" /></div>

<!-- password -->
<div class="item">Domain</div>
<div class="input"><select name="domain" id="domain">
  <option value="kppmining">KPPMINING</option>
</select></div>

<!-- login -->
<div class="item2">
<input onmouseover='this.src="img/login_hover.png"' 
onmouseout='this.src="img/login.png"'
type="image" name="validate" value="submit" 
src="img/login.png" border="0" title="Log-In" alt="Log-In">
</div>

</form>

</div>
<?
	// Set some basic Ldap Details//
	$ldap = new ldap();
	$ldap->s_Host('kppmining.net');
	$ldap->s_Domain('kppmining');
	$ldap->s_LdapSecure(false);
	$User = $_POST['username'];

if(isset($_POST['username'])){
    $ldap->s_User($_POST['username']);
    $ldap->s_Pass($_POST['password']);
    // First check we actually have a username and password set inside the ldap object.
    if($ldap->g_User() && $ldap->g_Pass()){
        if($ldap->LdapConn()){
            if($ldap->LdapBind()){			
			$_SESSION[LogIn]=date("Y-m-d H:i:s");
			$_SESSION[User]=$User;
			$_SESSION[SNama]=$A;
			$_SESSION[NamaSec]=$N;
			$_SESSION[Dept]=$T;
				echo ("
						<body>  
						<script language=JavaScript>
						window.open ('//bdmaapco401.kppmining.net.kppmining.net/Login.aspx?US=$User', '','location=yes, statusbar=yes,width=3000,height=1000');close()</SCRIPT></BODY>");
            }else{
                echo "Invalid credentials";
            }
        }else{
            echo "ldap server not available";
        }
    }else{
        echo "blank fields detected";
    }   
}
?>

</body>
</html>