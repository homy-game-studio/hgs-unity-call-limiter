[![semantic-release](https://img.shields.io/badge/%20%20%F0%9F%93%A6%F0%9F%9A%80-semantic--release-e10079.svg)](https://github.com/semantic-release/semantic-release)
[![openupm](https://img.shields.io/npm/v/com.hgs.call-limiter?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.hgs.call-limiter/)

# Introduction

**HGS Call Limiter** implements the concept of `Throttle` and `Debounce` using C#. Use both to prevent massive method calls.

![](images/introduction.gif)

## Throttle

Dont't allows function to execute more than once every x seconds.
Is commonly used to smooth user input actions.

### Sample

```cs
using HGS.CallLimiter

public class WeaponFire: MonoBehaviour
{
  [SerializeField] float fireRatio = 1;

  Throttle _fireThrottle = new Throttle();

  void Fire()
  {
   Debug.Log("fire");
  }

  void Update()
  {
    if(Input.GetMouseButton(0)){
      _fireThrottle.Run(Fire, fireRatio);
    }
  }
}
```

## Debounce

The debounce pattern allows only last function call. Whenever function is called, the internal call timer is reset, when call timer reach end, the method it will be called.

Is commonly used to reduce API calls.

### Sample

```cs
using HGS.CallLimiter

public class WeaponAutoReload: MonoBehaviour
{
  [SerializeField] float debounceInterval = 1;

  Debounce _reloadDebounce = new Debounce();

  void Reload()
  {
   Debug.Log("Reload");
  }

  void Update()
  {
    if(Input.GetMouseButton(0))
    {
      _reloadDebounce.Run(Reload, debounceInterval, this);
    }
  }
}
```

## Installation

OpenUPM:

`openupm add com.hgs.call-limiter`

Package Manager:

`https://github.com/homy-game-studio/hgs-unity-call-limiter.git#upm`

Or specify version:

`https://github.com/homy-game-studio/hgs-unity-call-limiter.git#2.0.0`

# Samples

You can see all samples directly in **Package Manager** window.

![](images/sample.png)

# Contrib

If you found any bugs, have any suggestions or questions, please create an issue on github. If you want to contribute code, fork the project and follow the best practices below, and make a pull request.

## Namespace Convention

To avoid script collisions, all scripts of this package is covered by `HGS.CallLimiter` namespace.

## Branchs

- `master` -> Keeps the unity project to development purposes.
- `upm` -> Copy of folder content `Assets/Package` to release after pull request in `master`.

Whenever a change is detected on the `master` branch, CI gets the contents of `Assets/Package`, and pushes in `upm` branch.

## Commit Convention

This package uses [semantic-release](https://github.com/semantic-release/semantic-release) to facilitate the release and versioning system. Please use angular commit convention:

```
<type>(<scope>): <short summary>
  │       │             │
  │       │             └─⫸ Summary in present tense. Not capitalized. No period at the end.
  │       │
  │       └─⫸ Commit Scope: Namespace, script name, etc..
  │
  └─⫸ Commit Type: build|ci|docs|feat|fix|perf|refactor|test
```

`Type`.:

- build: Changes that affect the build system or external dependencies (example scopes: package system)
- ci: Changes to our CI configuration files and scripts (example scopes: Circle, - BrowserStack, SauceLabs)
- docs: Documentation only changes
- feat: A new feature
- fix: A bug fix
- perf: A code change that improves performance
- refactor: A code change that neither fixes a bug nor adds a feature
- test: Adding missing tests or correcting existing tests
