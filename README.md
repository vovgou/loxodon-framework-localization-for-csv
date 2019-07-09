![](docs/images/icon.png)

# Loxodon Framework Localization For CSV

[![license](https://img.shields.io/badge/license-MIT-blue.png)](https://github.com/cocowolf/loxodon-framework-localization-for-csv/blob/master/LICENSE)
[![release](https://img.shields.io/badge/release-v1.0.0-blue.png)](https://github.com/cocowolf/loxodon-framework-localization-for-csv/releases)


*开发者 Clark*

要求Unity 2018.4或者更高版本

## 要求 ##

[Loxodon Framework](https://github.com/cocowolf/loxodon-framework)

本项目作为Loxodon.Framework插件，必须在Loxodon.Framework环境下使用，请在安装使用前先安装Loxodon.Framework框架。

## 介绍 ##

本插件扩展了Localization的功能，支持使用CSV格式的本地化配置文件，配置文件格式如下。

- key：配置文件的key，不能为空，此列必须存在。
- type：配置文件值的类型，此列必须存在。如：字符串类型 string ，整形数组 int-array
- description:描述，可以为空，并且此列可以省略
- default：默认值，最好不要为空,如果此列不存在，则会使用值的第一列作为默认列
- zh:中文配置，zh取值自CultureInfo.TwoLetterISOLanguageName，如果字段为空则使用默认配置
- zh-CN：中国，简体中文配置,zh-CN取值自CultureInfo.Name，如果字段为空，则使用zh的配置

以上只有key列和type列是必须存在的，其他可以根据实际情况添加或者省略。

**关于值的本地化查询规则是根据System.Globalization.CultureInfo类的TwoLetterISOLanguageName和Name字段来查询的。
优先按CultureInfo.Name查询，如果不存在则使用CultureInfo.TwoLetterISOLanguageName查询，最后才会使用默认值，比如下图中，如果当前语言是zh-CN的话，优先使用zh-CN的配置，如果不存在zh-CN的列或者zh-CN配置为空，则使用zh列的配置，如果zh列不存在或者字段为空则使用默认列的配置。**

![](Docs/csv.png)

#### 支持的类型 ####

 默认支持以下所有类型和他们的数组类型，通过自定义类型转换器ITypeConverter，可以支持新的数据类型。基本数据类型如下，数组类型是在基本类型后添加后缀"-array",比如字符串的数组：string-array

    string
    boolean
    sbyte
    byte
    short
    ushort
    int
    uint
    long
    ulong
    char
    float
    double
    decimal
    datetime
    vector2
    vector3
    vector4
    color


## 联系方式
邮箱: [yangpc.china@gmail.com](mailto:yangpc.china@gmail.com)   
网站: [https://cocowolf.github.io/loxodon-framework/](https://cocowolf.github.io/loxodon-framework/)  
QQ群: 622321589 [![](https://pub.idqqimg.com/wpa/images/group.png)](https:////shang.qq.com/wpa/qunwpa?idkey=71c1e43c24900ee84aeffc76fb67c0bacddc3f62a516fe80eae6b9521f872c59)
