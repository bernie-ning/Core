﻿#region Copyright
// Copyright (c) 2009 - 2010, Kazi Manzur Rashid <kazimanzurrashid@gmail.com>.
// This source is subject to the Microsoft Public License. 
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL. 
// All other rights reserved.
#endregion

namespace MvcExtensions.FluentMetadata.Tests
{
    using System;
    using Xunit;

    public class StringMetadataItemBuilderTests
    {
        private readonly ModelMetadataItemBuilder<string> builder;

        public StringMetadataItemBuilderTests()
        {
            builder = new ModelMetadataItemBuilder<string>(new ModelMetadataItem());
        }

        [Fact]
        public void Should_be_able_to_set_email_expression()
        {
            var previousExpression = StringMetadataItemBuilder.EmailExpression;

            StringMetadataItemBuilder.EmailExpression = @"ffff";

            Assert.Equal(@"ffff", StringMetadataItemBuilder.EmailExpression);

            StringMetadataItemBuilder.EmailExpression = previousExpression;
        }

        [Fact]
        public void Should_be_able_to_set_email_error_message()
        {
            var previousErrorMessage = StringMetadataItemBuilder.EmailErrorMessage;

            StringMetadataItemBuilder.EmailErrorMessage = @"Dummy message";

            Assert.Equal(@"Dummy message", StringMetadataItemBuilder.EmailErrorMessage);

            StringMetadataItemBuilder.EmailErrorMessage = previousErrorMessage;
        }

        [Fact]
        public void Should_be_able_to_set_url_expression()
        {
            var previousExpression = StringMetadataItemBuilder.UrlExpression;

            StringMetadataItemBuilder.UrlExpression = @"ffff";

            Assert.Equal(@"ffff", StringMetadataItemBuilder.UrlExpression);

            StringMetadataItemBuilder.UrlExpression = previousExpression;
        }

        [Fact]
        public void Should_be_able_to_set_url_error_message()
        {
            var previousErrorMessage = StringMetadataItemBuilder.UrlErrorMessage;

            StringMetadataItemBuilder.UrlErrorMessage = @"Dummy message";

            Assert.Equal(@"Dummy message", StringMetadataItemBuilder.UrlErrorMessage);

            StringMetadataItemBuilder.UrlErrorMessage = previousErrorMessage;
        }

        [Fact]
        public void Should_be_able_to_set_display_format()
        {
            builder.DisplayFormat("{0:d}");

            Assert.Equal("{0:d}", builder.Item.DisplayFormat());
        }

        [Fact]
        public void Should_be_able_to_set_edit_format()
        {
            builder.EditFormat("{0:d}");

            Assert.Equal("{0:d}", builder.Item.EditFormat());
        }

        [Fact]
        public void Should_be_able_to_set_format()
        {
            builder.Format("{0:d}");

            Assert.Equal("{0:d}", builder.Item.DisplayFormat());
            Assert.Equal("{0:d}", builder.Item.EditFormat());
        }

        [Fact]
        public void Should_be_able_to_set_apply_format_in_editmode()
        {
            builder.ApplyFormatInEditMode();

            Assert.True(builder.Item.ApplyFormatInEditMode);
        }

        [Fact]
        public void Should_be_able_to_set_as_email()
        {
            builder.AsEmail();

            var item = builder.Item;
            Assert.Equal("EmailAddress", item.TemplateName);
            Assert.NotEmpty(item.Validations);
        }

        [Fact]
        public void Setting_as_email_should_throw_exception_when_there_is_an_active_expression_validation()
        {
            builder.AsUrl();
            builder.AsEmail();

            Assert.Throws<InvalidOperationException>(() => builder.Item);
        }

        [Fact]
        public void Should_be_able_to_set_as_html()
        {
            builder.AsHtml();

            Assert.Equal("Html", builder.Item.TemplateName);
        }

        [Fact]
        public void Should_be_able_to_set_as_url()
        {
            builder.AsUrl();

            var item = builder.Item;
            Assert.Equal("Url", item.TemplateName);
            Assert.NotEmpty(item.Validations);
        }

        [Fact]
        public void Setting_as_url_should_throw_exception_when_there_is_an_active_expression_validation()
        {
            builder.AsEmail();
            builder.AsUrl();

            Assert.Throws<InvalidOperationException>(() => builder.Item);
        }

        [Fact]
        public void Should_be_able_to_set_as_multiline_text()
        {
            builder.AsMultilineText();

            Assert.Equal("MultilineText", builder.Item.TemplateName);
        }

        [Fact]
        public void Should_be_able_to_set_as_password()
        {
            builder.AsPassword();

            Assert.Equal("Password", builder.Item.TemplateName);
        }

        [Fact]
        public void Should_be_able_to_set_expression()
        {
            builder.Expression("foo");

            Assert.NotEmpty(builder.Item.Validations);
        }

        [Fact]
        public void Should_be_able_to_set_expression_with_text_message()
        {
            builder.Expression("foo", "Value must match the pattern");

            Assert.NotEmpty(builder.Item.Validations);
        }

        [Fact]
        public void Should_be_able_to_set_expression_with_type_and_resource_name()
        {
            builder.Expression("foo", typeof(object), "foo");

            Assert.NotEmpty(builder.Item.Validations);
        }

        [Fact]
        public void Should_be_able_to_set_maximum_length()
        {
            builder.MaximumLength(24);

            Assert.NotEmpty(builder.Item.Validations);
        }

        [Fact]
        public void Should_be_able_to_set_maximum_length_with_text_message()
        {
            builder.MaximumLength(24, "Value must be less than or equal to 24 characters.");

            Assert.NotEmpty(builder.Item.Validations);
        }

        [Fact]
        public void Should_be_able_to_set_maximum_length_with_type_and_resource_name()
        {
            builder.MaximumLength(24, typeof(object), "foo");

            Assert.NotEmpty(builder.Item.Validations);
        }

        [Fact]
        public void Should_be_able_to_set_minimum_length()
        {
            builder.MinimumLength(24);

            Assert.NotEmpty(builder.Item.Validations);
        }

        [Fact]
        public void Should_be_able_to_set_minimum_length_with_text_message()
        {
            builder.MinimumLength(24, "Value must be grater than or equal to 24 characters.");

            Assert.NotEmpty(builder.Item.Validations);
        }

        [Fact]
        public void Should_be_able_to_set_minimum_length_with_type_and_resource_name()
        {
            builder.MinimumLength(24, typeof(object), "foo");

            Assert.NotEmpty(builder.Item.Validations);
        }
    }
}