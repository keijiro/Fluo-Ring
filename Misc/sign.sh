#!/bin/sh

APP_NAME="Fluo"
APP_DIR=${APP_NAME}.app
APP_ZIP=${APP_NAME}.zip

chmod -R a+xr $APP_DIR

codesign --deep --force --verify --verbose --timestamp --options runtime \
  --entitlements "Fluo.entitlements" \
  --sign "Developer ID Application: Keijiro Takahashi (N6V3488B33)" \
  $APP_DIR

ditto -c -k --sequesterRsrc --keepParent $APP_DIR $APP_ZIP

xcrun notarytool submit $APP_ZIP --keychain-profile NotaryProfile --wait
xcrun stapler staple $APP_DIR

spctl --assess --type execute -vv $APP_DIR
codesign -dv --verbose=4 $APP_DIR

rm $APP_ZIP
