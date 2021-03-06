USE [Dictionary]
GO
/****** Object:  Table [dbo].[SpeechParts]    Script Date: 07/10/2013 18:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpeechParts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PartName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_SpeechParts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Languages]    Script Date: 07/10/2013 18:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Language] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Words]    Script Date: 07/10/2013 18:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Words](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LanguageId] [int] NOT NULL,
	[Word] [nvarchar](50) NOT NULL,
	[SpeechPartId] [int] NOT NULL,
 CONSTRAINT [PK_Words] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Explanations]    Script Date: 07/10/2013 18:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Explanations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text] [ntext] NOT NULL,
	[LanguageId] [int] NOT NULL,
 CONSTRAINT [PK_Explanations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WordsExplanations]    Script Date: 07/10/2013 18:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WordsExplanations](
	[WordId] [int] NOT NULL,
	[ExplanationId] [int] NOT NULL,
 CONSTRAINT [PK_WordsExplanations] PRIMARY KEY CLUSTERED 
(
	[WordId] ASC,
	[ExplanationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Antonyms]    Script Date: 07/10/2013 18:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Antonyms](
	[WordId] [int] NOT NULL,
	[AntonymId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hyponyms]    Script Date: 07/10/2013 18:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hyponyms](
	[WordId] [int] NOT NULL,
	[HyponymId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hypernyms]    Script Date: 07/10/2013 18:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hypernyms](
	[WordId] [int] NOT NULL,
	[HypernymId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Translations]    Script Date: 07/10/2013 18:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Translations](
	[WordId] [int] NOT NULL,
	[TranslationId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Synonyms]    Script Date: 07/10/2013 18:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Synonyms](
	[WordId] [int] NOT NULL,
	[SynonymId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Antonyms_Words]    Script Date: 07/10/2013 18:21:34 ******/
ALTER TABLE [dbo].[Antonyms]  WITH CHECK ADD  CONSTRAINT [FK_Antonyms_Words] FOREIGN KEY([WordId])
REFERENCES [dbo].[Words] ([Id])
GO
ALTER TABLE [dbo].[Antonyms] CHECK CONSTRAINT [FK_Antonyms_Words]
GO
/****** Object:  ForeignKey [FK_Antonyms_Words1]    Script Date: 07/10/2013 18:21:34 ******/
ALTER TABLE [dbo].[Antonyms]  WITH CHECK ADD  CONSTRAINT [FK_Antonyms_Words1] FOREIGN KEY([AntonymId])
REFERENCES [dbo].[Words] ([Id])
GO
ALTER TABLE [dbo].[Antonyms] CHECK CONSTRAINT [FK_Antonyms_Words1]
GO
/****** Object:  ForeignKey [FK_Explanations_Languages]    Script Date: 07/10/2013 18:21:34 ******/
ALTER TABLE [dbo].[Explanations]  WITH CHECK ADD  CONSTRAINT [FK_Explanations_Languages] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Languages] ([Id])
GO
ALTER TABLE [dbo].[Explanations] CHECK CONSTRAINT [FK_Explanations_Languages]
GO
/****** Object:  ForeignKey [FK_Hypernyms_Words]    Script Date: 07/10/2013 18:21:34 ******/
ALTER TABLE [dbo].[Hypernyms]  WITH CHECK ADD  CONSTRAINT [FK_Hypernyms_Words] FOREIGN KEY([WordId])
REFERENCES [dbo].[Words] ([Id])
GO
ALTER TABLE [dbo].[Hypernyms] CHECK CONSTRAINT [FK_Hypernyms_Words]
GO
/****** Object:  ForeignKey [FK_Hypernyms_Words1]    Script Date: 07/10/2013 18:21:34 ******/
ALTER TABLE [dbo].[Hypernyms]  WITH CHECK ADD  CONSTRAINT [FK_Hypernyms_Words1] FOREIGN KEY([HypernymId])
REFERENCES [dbo].[Words] ([Id])
GO
ALTER TABLE [dbo].[Hypernyms] CHECK CONSTRAINT [FK_Hypernyms_Words1]
GO
/****** Object:  ForeignKey [FK_Hyponyms_Words]    Script Date: 07/10/2013 18:21:34 ******/
ALTER TABLE [dbo].[Hyponyms]  WITH CHECK ADD  CONSTRAINT [FK_Hyponyms_Words] FOREIGN KEY([WordId])
REFERENCES [dbo].[Words] ([Id])
GO
ALTER TABLE [dbo].[Hyponyms] CHECK CONSTRAINT [FK_Hyponyms_Words]
GO
/****** Object:  ForeignKey [FK_Hyponyms_Words1]    Script Date: 07/10/2013 18:21:34 ******/
ALTER TABLE [dbo].[Hyponyms]  WITH CHECK ADD  CONSTRAINT [FK_Hyponyms_Words1] FOREIGN KEY([HyponymId])
REFERENCES [dbo].[Words] ([Id])
GO
ALTER TABLE [dbo].[Hyponyms] CHECK CONSTRAINT [FK_Hyponyms_Words1]
GO
/****** Object:  ForeignKey [FK_Synonyms_Words]    Script Date: 07/10/2013 18:21:34 ******/
ALTER TABLE [dbo].[Synonyms]  WITH CHECK ADD  CONSTRAINT [FK_Synonyms_Words] FOREIGN KEY([SynonymId])
REFERENCES [dbo].[Words] ([Id])
GO
ALTER TABLE [dbo].[Synonyms] CHECK CONSTRAINT [FK_Synonyms_Words]
GO
/****** Object:  ForeignKey [FK_Synonyms_Words_reverse]    Script Date: 07/10/2013 18:21:34 ******/
ALTER TABLE [dbo].[Synonyms]  WITH CHECK ADD  CONSTRAINT [FK_Synonyms_Words_reverse] FOREIGN KEY([WordId])
REFERENCES [dbo].[Words] ([Id])
GO
ALTER TABLE [dbo].[Synonyms] CHECK CONSTRAINT [FK_Synonyms_Words_reverse]
GO
/****** Object:  ForeignKey [FK_Translations_Words]    Script Date: 07/10/2013 18:21:34 ******/
ALTER TABLE [dbo].[Translations]  WITH CHECK ADD  CONSTRAINT [FK_Translations_Words] FOREIGN KEY([WordId])
REFERENCES [dbo].[Words] ([Id])
GO
ALTER TABLE [dbo].[Translations] CHECK CONSTRAINT [FK_Translations_Words]
GO
/****** Object:  ForeignKey [FK_Translations_Words1]    Script Date: 07/10/2013 18:21:34 ******/
ALTER TABLE [dbo].[Translations]  WITH CHECK ADD  CONSTRAINT [FK_Translations_Words1] FOREIGN KEY([TranslationId])
REFERENCES [dbo].[Words] ([Id])
GO
ALTER TABLE [dbo].[Translations] CHECK CONSTRAINT [FK_Translations_Words1]
GO
/****** Object:  ForeignKey [FK_Words_Languages]    Script Date: 07/10/2013 18:21:34 ******/
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_Languages] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Languages] ([Id])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_Languages]
GO
/****** Object:  ForeignKey [FK_Words_SpeechParts]    Script Date: 07/10/2013 18:21:34 ******/
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_SpeechParts] FOREIGN KEY([SpeechPartId])
REFERENCES [dbo].[SpeechParts] ([Id])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_SpeechParts]
GO
/****** Object:  ForeignKey [FK_WordsExplanations_Explanations]    Script Date: 07/10/2013 18:21:34 ******/
ALTER TABLE [dbo].[WordsExplanations]  WITH CHECK ADD  CONSTRAINT [FK_WordsExplanations_Explanations] FOREIGN KEY([ExplanationId])
REFERENCES [dbo].[Explanations] ([Id])
GO
ALTER TABLE [dbo].[WordsExplanations] CHECK CONSTRAINT [FK_WordsExplanations_Explanations]
GO
/****** Object:  ForeignKey [FK_WordsExplanations_Words]    Script Date: 07/10/2013 18:21:34 ******/
ALTER TABLE [dbo].[WordsExplanations]  WITH CHECK ADD  CONSTRAINT [FK_WordsExplanations_Words] FOREIGN KEY([WordId])
REFERENCES [dbo].[Words] ([Id])
GO
ALTER TABLE [dbo].[WordsExplanations] CHECK CONSTRAINT [FK_WordsExplanations_Words]
GO
