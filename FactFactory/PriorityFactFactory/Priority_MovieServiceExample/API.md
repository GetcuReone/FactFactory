<a name='assembly'></a>
# GetcuReone.Priority_MovieServiceExample

## Contents

- [ArrayExtensions](#T--ArrayExtensions '.ArrayExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ArrayExtensions-IsNullOrEmpty``1-``0[]- 'ArrayExtensions.IsNullOrEmpty``1(``0[])')
- [EnumerableExtensions](#T--EnumerableExtensions '.EnumerableExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-EnumerableExtensions-IsNullOrEmpty``1-System-Collections-Generic-IEnumerable{``0}- 'EnumerableExtensions.IsNullOrEmpty``1(System.Collections.Generic.IEnumerable{``0})')
- [ListExtensions](#T--ListExtensions '.ListExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ListExtensions-IsNullOrEmpty``1-System-Collections-Generic-List{``0}- 'ListExtensions.IsNullOrEmpty``1(System.Collections.Generic.List{``0})')
- [MovieDiscountFact](#T-Priority_MovieServiceExample-Facts-MovieDiscountFact 'Priority_MovieServiceExample.Facts.MovieDiscountFact')
- [MovieFact](#T-Priority_MovieServiceExample-Facts-MovieFact 'Priority_MovieServiceExample.Facts.MovieFact')
- [MovieIdFact](#T-Priority_MovieServiceExample-Facts-MovieIdFact 'Priority_MovieServiceExample.Facts.MovieIdFact')
- [MoviePurchasePriceFact](#T-Priority_MovieServiceExample-Facts-MoviePurchasePriceFact 'Priority_MovieServiceExample.Facts.MoviePurchasePriceFact')
- [UserEmailFact](#T-Priority_MovieServiceExample-Facts-UserEmailFact 'Priority_MovieServiceExample.Facts.UserEmailFact')
- [UserFact](#T-Priority_MovieServiceExample-Facts-UserFact 'Priority_MovieServiceExample.Facts.UserFact')

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

<a name='T-Priority_MovieServiceExample-Facts-MovieDiscountFact'></a>
## MovieDiscountFact `type`

##### Namespace

Priority_MovieServiceExample.Facts

##### Summary

The fact stores information about the size of the discount

<a name='T-Priority_MovieServiceExample-Facts-MovieFact'></a>
## MovieFact `type`

##### Namespace

Priority_MovieServiceExample.Facts

##### Summary

The fact stores information about the movie

<a name='T-Priority_MovieServiceExample-Facts-MovieIdFact'></a>
## MovieIdFact `type`

##### Namespace

Priority_MovieServiceExample.Facts

##### Summary

Fact stores movie id information.

<a name='T-Priority_MovieServiceExample-Facts-MoviePurchasePriceFact'></a>
## MoviePurchasePriceFact `type`

##### Namespace

Priority_MovieServiceExample.Facts

##### Summary

The fact stores information about the cost of buying a movie for the user.

<a name='T-Priority_MovieServiceExample-Facts-UserEmailFact'></a>
## UserEmailFact `type`

##### Namespace

Priority_MovieServiceExample.Facts

##### Summary

Fact stores user email information

<a name='T-Priority_MovieServiceExample-Facts-UserFact'></a>
## UserFact `type`

##### Namespace

Priority_MovieServiceExample.Facts

##### Summary

Fact stores user information
