
# react-native-app-center

Currently only supports windows

## Getting started

`$ npm install react-native-app-center --save`

### Mostly automatic installation

`$ react-native link react-native-app-center`

### Manual installation


#### iOS

1. In XCode, in the project navigator, right click `Libraries` ➜ `Add Files to [your project's name]`
2. Go to `node_modules` ➜ `react-native-app-center` and add `RNAppCenter.xcodeproj`
3. In XCode, in the project navigator, select your project. Add `libRNAppCenter.a` to your project's `Build Phases` ➜ `Link Binary With Libraries`
4. Run your project (`Cmd+R`)<

#### Android

1. Open up `android/app/src/main/java/[...]/MainActivity.java`
  - Add `import com.reactlibrary.RNAppCenterPackage;` to the imports at the top of the file
  - Add `new RNAppCenterPackage()` to the list returned by the `getPackages()` method
2. Append the following lines to `android/settings.gradle`:
  	```
  	include ':react-native-app-center'
  	project(':react-native-app-center').projectDir = new File(rootProject.projectDir, 	'../node_modules/react-native-app-center/android')
  	```
3. Insert the following lines inside the dependencies block in `android/app/build.gradle`:
  	```
      compile project(':react-native-app-center')
  	```

#### Windows
[Read it! :D](https://github.com/ReactWindows/react-native)

1. In Visual Studio add the `RNAppCenter.sln` in `node_modules/react-native-app-center/windows/RNAppCenter.sln` folder to their solution, reference from their app.
2. Open up your `MainPage.cs` app
  - Add `using App.Center.RNAppCenter;` to the usings at the top of the file
  - Add `new RNAppCenterPackage()` to the `List<IReactPackage>` returned by the `Packages` method


## Usage
```javascript
import RNAppCenter from 'react-native-app-center';

// TODO: What to do with the module?
RNAppCenter;
```
  
