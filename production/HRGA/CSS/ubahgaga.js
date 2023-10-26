function ubahGaya(pilih, nama, isi) {
	el = document.all ? document.all : document.getElementsByTagName('*');
	n = el.length;
	for (i=0; i<n; i++) {
		node = el[i];
		if (node.className == pilih) {
			eval("node.style." + nama + " = '" + isi + "'");
		}
	}
}

function tampilBahasa(b1, b2, b3) {
	if (b1) ubahGaya('teksindo', 'display', '');
	if (b1) ubahGaya('ringkasindo', 'display', '');
	if (b1) ubahGaya('subjudul2id', 'display', '');
	if (b1) ubahGaya('judulindo', 'display', '');
	if (!b1) ubahGaya('teksindo', 'display', 'none');
	if (!b1) ubahGaya('ringkasindo', 'display', 'none');
	if (!b1) ubahGaya('subjudul2id', 'display', 'none');
	if (!b1) ubahGaya('judulindo', 'display', 'none');
	
	if (b2) ubahGaya('teksinggris', 'display', '');
	if (b2) ubahGaya('ringkasinggris', 'display', '');
	if (b2) ubahGaya('subjudul2en', 'display', '');
	if (b2) ubahGaya('judulinggris', 'display', '');
	if (!b2) ubahGaya('teksinggris', 'display', 'none');
	if (!b2) ubahGaya('ringkasinggris', 'display', 'none');
	if (!b2) ubahGaya('subjudul2en', 'display', 'none');
	if (!b2) ubahGaya('judulinggris', 'display', 'none');
	
	if (b3) ubahGaya('pemisah', 'display', '');
	if (!b3) ubahGaya('pemisah', 'display', 'none');
}
