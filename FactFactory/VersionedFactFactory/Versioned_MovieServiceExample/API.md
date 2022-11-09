<a name='assembly'></a>
# GetcuReone.Versioned_MovieServiceExample

## Contents

- [ArrayExtensions](#T--ArrayExtensions '.ArrayExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ArrayExtensions-IsNullOrEmpty``1-``0[]- 'ArrayExtensions.IsNullOrEmpty``1(``0[])')
- [EnumerableExtensions](#T--EnumerableExtensions '.EnumerableExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-EnumerableExtensions-IsNullOrEmpty``1-System-Collections-Generic-IEnumerable{``0}- 'EnumerableExtensions.IsNullOrEmpty``1(System.Collections.Generic.IEnumerable{``0})')
- [ListExtensions](#T--ListExtensions '.ListExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ListExtensions-IsNullOrEmpty``1-System-Collections-Generic-List{``0}- 'ListExtensions.IsNullOrEmpty``1(System.Collections.Generic.List{``0})')
- [MovieDiscountFact](#T-Versioned_MovieServiceExample-Facts-MovieDiscountFact 'Versioned_MovieServiceExample.Facts.MovieDiscountFact')
- [MovieFact](#T-Versioned_MovieServiceExample-Facts-MovieFact 'Versioned_MovieServiceExample.Facts.MovieFact')
- [MovieIdFact](#T-Versioned_MovieServiceExample-Facts-MovieIdFact 'Versioned_MovieServiceExample.Facts.MovieIdFact')
- [MoviePurchasePriceFact](#T-Versioned_MovieServiceExample-Facts-MoviePurchasePriceFact 'Versioned_MovieServiceExample.Facts.MoviePurchasePriceFact')
- [MovieServiceExample](#T-Versioned_MovieServiceExample-MovieServiceExample 'Versioned_MovieServiceExample.MovieServiceExample')
  - [GetAllVersion()](#M-Versioned_MovieServiceExample-MovieServiceExample-GetAllVersion-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{GetcuReone-FactFactory-Entities-WantAction}- 'Versioned_MovieServiceExample.MovieServiceExample.GetAllVersion(GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{GetcuReone.FactFactory.Entities.WantAction})')
- [UserEmailFact](#T-Versioned_MovieServiceExample-Facts-UserEmailFact 'Versioned_MovieServiceExample.Facts.UserEmailFact')
- [UserFact](#T-Versioned_MovieServiceExample-Facts-UserFact 'Versioned_MovieServiceExample.Facts.UserFact')

<a name='T--ArrayExtensions'></a>
## ArrayExtensions `type`

##### Namespace



<a name='M-ArrayExtensions-IsNullOrEmpty``1-``0[]-'></a>
### IsNullOrEmpty\`\`1(items) `method`

##### Summary

True - `items` is null or empty.

##### Returns

`items` is empty or null?

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| items | [\`\`0[]](#T-``0[] '``0[]') | Collection. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TItem | Type items. |

<a name='T--EnumerableExtensions'></a>
## EnumerableExtensions `type`

##### Namespace



<a name='M-EnumerableExtensions-IsNullOrEmpty``1-System-Collections-Generic-IEnumerable{``0}-'></a>
### IsNullOrEmpty\`\`1(items) `method`

##### Summary

True - `items` is null or empty.

##### Returns

`items` is empty or null?

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| items | [System.Collections.Generic.IEnumerable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{``0}') | Collection. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TItem | Type items. |

<a name='T--ListExtensions'></a>
## ListExtensions `type`

##### Namespace



<a name='M-ListExtensions-IsNullOrEmpty``1-System-Collections-Generic-List{``0}-'></a>
### IsNullOrEmpty\`\`1(items) `method`

##### Summary

True - `items` is null or empty.

##### Returns

`items` is empty or null?

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| items | [System.Collections.Generic.List{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{``0}') | Collection. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TItem | Type items. |

<a name='T-Versioned_MovieServiceExample-Facts-MovieDiscountFact'></a>
## MovieDiscountFact `type`

##### Namespace

Versioned_MovieServiceExample.Facts

##### Summary

The fact stores information about the size of the discount

<a name='T-Versioned_MovieServiceExample-Facts-MovieFact'></a>
## MovieFact `type`

##### Namespace

Versioned_MovieServiceExample.Facts

##### Summary

The fact stores information about the movie

<a name='T-Versioned_MovieServiceExample-Facts-MovieIdFact'></a>
## MovieIdFact `type`

##### Namespace

Versioned_MovieServiceExample.Facts

##### Summary

Fact stores movie id information

<a name='T-Versioned_MovieServiceExample-Facts-MoviePurchasePriceFact'></a>
## MoviePurchasePriceFact `type`

##### Namespace

Versioned_MovieServiceExample.Facts

##### Summary

The fact stores information about the cost of buying a movie for the user

<a name='T-Versioned_MovieServiceExample-MovieServiceExample'></a>
## MovieServiceExample `type`

##### Namespace

Versioned_MovieServiceExample

<a name='M-Versioned_MovieServiceExample-MovieServiceExample-GetAllVersion-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{GetcuReone-FactFactory-Entities-WantAction}-'></a>
### GetAllVersion() `method`

##### Summary

The method returns instances of all versions used in the rules.

##### Returns



##### Parameters

This method has no parameters.

<a name='T-Versioned_MovieServiceExample-Facts-UserEmailFact'></a>
## UserEmailFact `type`

##### Namespace

Versioned_MovieServiceExample.Facts

##### Summary

Fact stores user email information

<a name='T-Versioned_MovieServiceExample-Facts-UserFact'></a>
## UserFact `type`

##### Namespace

Versioned_MovieServiceExample.Facts

##### Summary

Fact stores user information
