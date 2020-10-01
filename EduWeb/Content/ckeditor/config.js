/**
 * @license Copyright (c) 2003-2019, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
	config.syntaxhighlight_lang = 'csharp';
	config.syntaxhighlight_hideControls = true;
	config.language = 'vi';
	config.filebrowersBrowerUrl = '/Content/ckfinder/ckfinder.html';
	config.filebrowersImageUrl = '/Content/ckfinder/ckfinder.html?Type=Images';
	config.filebrowersFlashUrl = '/Content/ckfinder/ckfinder.html?Type=Flash';
	config.filebrowersUploadUrl = '/Content/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
	config.filebrowersImageUploadUrl = '/Content/Uploads';
	config.filebrowersFlashUploadUrl = '/Content/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';

	CKFinder.setupCKEditor(null, '/Content/ckfinder/');
};
