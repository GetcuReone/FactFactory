<a name='assembly'></a>
# GetcuReone.MovieServiceExample

## Contents

- [ArrayExtensions](#T--ArrayExtensions '.ArrayExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ArrayExtensions-IsNullOrEmpty``1-``0[]- 'ArrayExtensions.IsNullOrEmpty``1(``0[])')
- [EnumerableExtensions](#T--EnumerableExtensions '.EnumerableExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-EnumerableExtensions-IsNullOrEmpty``1-System-Collections-Generic-IEnumerable{``0}- 'EnumerableExtensions.IsNullOrEmpty``1(System.Collections.Generic.IEnumerable{``0})')
- [ListExtensions](#T--ListExtensions '.ListExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ListExtensions-IsNullOrEmpty``1-System-Collections-Generic-List{``0}- 'ListExtensions.IsNullOrEmpty``1(System.Collections.Generic.List{``0})')
  - [ToReadOnlyCollection\`\`1(items)](#M-ListExtensions-ToReadOnlyCollection``1-System-Collections-Generic-IList{``0}- 'ListExtensions.ToReadOnlyCollection``1(System.Collections.Generic.IList{``0})')
- [MovieDiscountFact](#T-MovieServiceExample-Facts-MovieDiscountFact 'MovieServiceExample.Facts.MovieDiscountFact')
- [MovieFact](#T-MovieServiceExample-Facts-MovieFact 'MovieServiceExample.Facts.MovieFact')
- [MovieIdFact](#T-MovieServiceExample-Facts-MovieIdFact 'MovieServiceExample.Facts.MovieIdFact')
- [MoviePurchasePriceFact](#T-MovieServiceExample-Facts-MoviePurchasePriceFact 'MovieServiceExample.Facts.MoviePurchasePriceFact')
- [MoviePurchasePriceFactAsync](#T-MovieServiceExample-Facts-MoviePurchasePriceFactAsync 'MovieServiceExample.Facts.MoviePurchasePriceFactAsync')
- [UserEmailFact](#T-MovieServiceExample-Facts-UserEmailFact 'MovieServiceExample.Facts.UserEmailFact')
- [UserFact](#T-MovieServiceExample-Facts-UserFact 'MovieServiceExample.Facts.UserFact')

<a name='T--ArrayExtensions'></a>
## ArrayExtensions `type`

##### Namespace



<a name='M-ArrayExtensions-IsNullOrEmpty``1-``0[]-'></a>
### IsNullOrEmpty\`\`1(items) `method`

##### Summary

True - `items` is null or empty

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

True - `items` is null or empty

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

True - `items` is null or empty

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

<a name='M-ListExtensions-ToReadOnlyCollection``1-System-Collections-Generic-IList{``0}-'></a>
### ToReadOnlyCollection\`\`1(items) `method`

##### Summary

Convert list to [ReadOnlyCollection\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.ObjectModel.ReadOnlyCollection`1 'System.Collections.ObjectModel.ReadOnlyCollection`1')

##### Returns

Read-only collection.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| items | [System.Collections.Generic.IList{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IList 'System.Collections.Generic.IList{``0}') | Coollection. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TItem | Type item. |

<a name='T-MovieServiceExample-Facts-MovieDiscountFact'></a>
## MovieDiscountFact `type`

##### Namespace

MovieServiceExample.Facts

##### Summary

The fact stores information about the size of the discount

<a name='T-MovieServiceExample-Facts-MovieFact'></a>
## MovieFact `type`

##### Namespace

MovieServiceExample.Facts

##### Summary

The fact stores information about the movie

<a name='T-MovieServiceExample-Facts-MovieIdFact'></a>
## MovieIdFact `type`

##### Namespace

MovieServiceExample.Facts

##### Summary

Fact stores movie id information

<a name='T-MovieServiceExample-Facts-MoviePurchasePriceFact'></a>
## MoviePurchasePriceFact `type`

##### Namespace

MovieServiceExample.Facts

##### Summary

The fact stores information about the cost of buying a movie for the user

<a name='T-MovieServiceExample-Facts-MoviePurchasePriceFactAsync'></a>
## MoviePurchasePriceFactAsync `type`

##### Namespace

MovieServiceExample.Facts

##### Summary

The fact stores information about the cost of buying a movie for the user

<a name='T-MovieServiceExample-Facts-UserEmailFact'></a>
## UserEmailFact `type`

##### Namespace

MovieServiceExample.Facts

##### Summary

Fact stores user email information

<a name='T-MovieServiceExample-Facts-UserFact'></a>
## UserFact `type`

##### Namespace

MovieServiceExample.Facts

##### Summary

Fact stores user information
