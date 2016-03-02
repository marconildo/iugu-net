﻿using iugu.net.Lib;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iugu.net.IntegratedTests
{
    [TestFixture(Category = "Payment")]
    public class PaymentTokenIntegratedTests
    {
        [Test]
        public async Task Create_a_new_payment_token_with_success()
        {
            // Arrange
            var expectedResponse = new PaymentTokenResponse
            {
                Id = "e06809b9da0a3118fa282a18c1f5dc09",
                Method = Constants.PaymentMethod.CREDIT_CARD
            };

            var paymentRequest = new PaymentTokenRequest
            {
                AccountId = "2d8b228d-4183-44b8-ad3b-b8ab0db2aacd",
                Method = Constants.PaymentMethod.CREDIT_CARD,
                Test = true,
                PaymentData = new PaymentInfoModel
                {
                    FirstName = "Rodrigo",
                    LastName = "Couto",
                    Month = "12",
                    Year = "2018",
                    Number = "4111111111111111",
                    VerificationValue = "123"
                }
            };

            PaymentTokenResponse paymentTokenResponse;

            // Act
            using (var apiClient = new PaymentToken())
            {
                paymentTokenResponse = await apiClient.CreateAsync(paymentRequest).ConfigureAwait(false);
            }

            // Assert
            Assert.That(paymentTokenResponse.Id, Is.Not.Empty);
            Assert.That(paymentTokenResponse.Method, Is.EqualTo(expectedResponse.Method));
        }
    }
}