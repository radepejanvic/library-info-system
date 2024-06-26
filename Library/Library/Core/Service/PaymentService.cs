﻿using Library.Core.Enum;
using Library.Core.Model;
using Library.Core.Repository.Interface;
using Library.Core.Service.Interface;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IBookCopyRepository _bookCopyRepository;
        private readonly IMembershipCardRepository _membershipCardRepository;
        private readonly IMembershipRepository _membershipRepository;
        private readonly IPaymentRepository _paymentRepository;
        public PaymentService(IBookCopyRepository bookCopyRepository, IMembershipCardRepository membershipCardRepository, 
            IMembershipRepository membershipRepository, IPaymentRepository paymentRepository)
        {
            _bookCopyRepository = bookCopyRepository;
            _membershipCardRepository = membershipCardRepository;
            _membershipRepository = membershipRepository;
            _paymentRepository = paymentRepository;
        }
        public float GetPrice(string inventoryNumber)
        {
            var bookCopy = _bookCopyRepository.Get(inventoryNumber);
            return bookCopy?.Price ?? 0.0f;
        }

        public float GetPrice(int MembershipCardId, DateTime date)
        {
            var membershipCard = _membershipCardRepository.Get(MembershipCardId);
            var membership = _membershipRepository.Get(membershipCard.MembershipId);

            if (date >= DateTime.Now)
            {
                return 0;
            }
            TimeSlot timeSlot = new TimeSlot(date, DateTime.Now);

            return timeSlot.GetDurationByDays() * membership.FinePerDay;
        }

        public void Add(Payment payment)
        {
            _paymentRepository.Add(payment);
        }
        public List<Payment> GetAllByDate()
        {
            return _paymentRepository.GetAllByDate();
        }

        public int GetAllByDateCount()
        {
            return _paymentRepository.GetAllByDate().Count();
        }

        public float GetAllByDateAmount()
        {
            return _paymentRepository.GetAllByDate().Sum(payment => payment.Amount);
        }

        public int GetAllDamagedByDateCount()
        {
            return _paymentRepository.GetAllByDate().Where(payment => payment.Reason == PaymentReason.DAMAGE).Count();
        }

        public float GetAllDamagedByDateAmount()
        {
            return _paymentRepository.GetAllByDate().Where(payment => payment.Reason == PaymentReason.DAMAGE).Sum(payment => payment.Amount);
        }

        public int GetAllLossByDateCount()
        {
            return _paymentRepository.GetAllByDate().Where(payment => payment.Reason == PaymentReason.LOSS).Count();
        }

        public float GetAllLossByDateAmount()
        {
            return _paymentRepository.GetAllByDate().Where(payment => payment.Reason == PaymentReason.LOSS).Sum(payment => payment.Amount);
        }

        public int GetAllDelayedByDateCount()
        {
            return _paymentRepository.GetAllByDate().Where(payment => payment.Reason == PaymentReason.DELAY).Count();
        }

        public float GetAllDelayedByDateAmount()
        {
            return _paymentRepository.GetAllByDate().Where(payment => payment.Reason == PaymentReason.DELAY).Sum(payment => payment.Amount);
        }
    }
}

